using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_3.Models;
using Tutorial_3.Services;

namespace Tutorial_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentDbService _dbService;

        public StudentsController(IStudentDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = StudentDbService.students;
            return Ok(result);
        }

        [HttpGet]
        [Route("{Index}")]

        public async Task<IActionResult> GetStudent(string Index)
        {
            try
            {
                return Ok(_dbService.GetStudent(Index));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Student with Index {Index} doesnt exists!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {
                return Ok(_dbService.AddStudent(student));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Student with Index {student.Index} alredt=y Exists");
            }
        }

        [HttpPut]
        [Route("{Index}")]
        public async Task<IActionResult> UpdateStudent(string Index,Student student)
        {
            try
            {
                return Ok(_dbService.UpdateStudent(Index,student));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, $"Student with Index {Index} Not Found");
            }
        }
        
        [HttpDelete]
        [Route("{Index}")]
        public async Task<IActionResult> DeleteStudent(string Index)
        {
            try
            {
                return Ok(_dbService.DeleteStudent(Index));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Student with Index {Index} Not Found");
            }
           
        }
    }
}

