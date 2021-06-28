using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using tutorial_8.DTOs.Request;
using tutorial_8.Models;


namespace tutorial_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {

        private Clinic_DbContext _context;

       
        public ClinicController(Clinic_DbContext context )
        {
            _context = context;
        }

        [Route("Doctor")]
        [HttpGet]
        public async Task<IActionResult> GetDoc()
        {
            var result = await _context.Doctors.Select(d => new
             {
                 IdDoctor = d.IdDoctor,
                 FirstName = d.FirstName,
                 LastName = d.LastName,
                 Email = d.Email
             }).ToListAsync(); 

            return Ok(result) ;
        }
        [Route("Doctor")]
        [HttpPost]
        public async Task<IActionResult> PostDoc(PostDoctorParametrsRequestDto doctor)
        {

            Doctor newDoc = new Doctor
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            _context.Doctors.Add(newDoc);
            await _context.SaveChangesAsync();

            return Ok("Doctor Added!");
        }
        [Route("Doctor/{idDoctor}")]
        [HttpDelete]

        public async Task<IActionResult> DeleteDoc(int idDoctor)
        {
            var result =  _context.Doctors.Where(x => x.IdDoctor == idDoctor).First();
            _context.Doctors.Remove((Doctor)result);
            await _context.SaveChangesAsync();

            return Ok("Doctor Has been Deleted");
                
        }
        [Route("Doctor/{idDoctor}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoc(UpdateDoctorPatametersRequestDto doctor, int IdDoctor)
        {
            var result = _context.Doctors.First(x => x.IdDoctor == IdDoctor);
            result.FirstName = doctor.FirstName;
            result.LastName = doctor.LastName;
            result.Email = doctor.Email;

            await _context.SaveChangesAsync();

            return Ok("Doctor Updated");
        }

        
    }
}
