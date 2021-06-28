using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.DTOs.Response;
using tutorial_8.Models;

namespace tutorial_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private Clinic_DbContext _context;

        public PrescriptionController(Clinic_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrescriptionWithAdditionalData()
        {
            var result = await _context.Prescriptions.Select(x => new GetListOfPrescriptionDto
            {
               IdPrescription = x.idPrescription,
               Date = x.Date,
               DueDate=x.DueDate,
               Doctor = x.Doctor.FirstName+" "+x.Doctor.LastName,
               Patient = x.Patient.FirstName+" "+x.Patient.LastName, 
               Medicament = x.Prescription_Medicaments.Select(y=> new GetMedicamentResponseDto 
               {
                   Name = y.Medicament.Name,
                   Description = y.Medicament.Description,
                   Type = y.Medicament.Type
               }) 
            }).ToListAsync();
            return Ok(result);
        }
    }
}
