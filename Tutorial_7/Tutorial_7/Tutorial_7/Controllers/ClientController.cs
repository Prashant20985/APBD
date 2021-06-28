using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_7.DTOs;
using Tutorial_7.Models;

namespace Tutorial_7.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        public readonly s20985Context _context;
        public ClientController(s20985Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetTrips()
        {
            var result = await _context.Trips.Select(x => new
            {
                Name = x.Name,
                Description = x.Description,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                MaxPeople = x.MaxPeople,
                Countries = x.CountryTrips.Select(y => new
                {
                    Name = y.IdCountryNavigation.Name
                }),
                Clients = x.ClientTrips.Select(z => new
                {
                    FirstName = z.IdClientNavigation.FirstName,
                    LastName = z.IdClientNavigation.LastName
                })

            }).OrderByDescending(desc => desc.DateFrom).ToListAsync();

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Data Not Found");
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("clients/{idClient}")]

        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var checkClient = await _context.Clients.FirstOrDefaultAsync(x => x.IdClient == idClient);
            var checkTour = await _context.ClientTrips.FirstOrDefaultAsync(x => x.IdClient == idClient);

            if (checkClient == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Client With Id {idClient} does not Exists!");
            }
            if (checkTour != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Client with Id {idClient} still has a tour");
            }

            var result = await _context.Clients.FirstOrDefaultAsync(x => x.IdClient == idClient);
            _context.Clients.Remove(result);

            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, $"Client with Id {idClient} is deleted");
        }

        [HttpPost]
        [Route("trips/{IdTrip}/clients")]
        public async Task<IActionResult> AssignTrips(int IdTrip, AssignCustomerRequestDto clients)
        {
            IdTrip = clients.IdTrip;

            var checkClientUsingPesel = await _context.Clients.FirstOrDefaultAsync(x => x.Pesel == clients.Pesel);

            if (checkClientUsingPesel == null)
            {
                _context.Clients.Add(new Client
                {
                    FirstName = clients.FirstName,
                    LastName = clients.LastName,
                    Email = clients.Email,
                    Telephone = clients.Telephone,
                    Pesel = clients.Pesel
                });

                await _context.SaveChangesAsync();
            }
            else
            {
                var checkForAlreadyBookedTrip = await _context.ClientTrips.FirstOrDefaultAsync(x => x.IdClient == checkClientUsingPesel.IdClient);
                if (checkForAlreadyBookedTrip != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"Client named {clients.FirstName} alredy has a trip");
                }
            }

            var checkTourExistance = await _context.Trips.FirstOrDefaultAsync(x => x.Name == clients.TripName);
            if (checkTourExistance != null)
            {
                _context.ClientTrips.Add(new ClientTrip
                {
                    IdClient = _context.Clients.Where(y => y.Pesel == clients.Pesel).Select(x => x.IdClient).Single(),
                    IdTrip = clients.IdTrip,
                    PaymentDate = clients.PaymentDate,
                    RegisteredAt = DateTime.Now
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Tour for {clients.TripName} is not available");
            }
            return Ok();
        }
    }
}
