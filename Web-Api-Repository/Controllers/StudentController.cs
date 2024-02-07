using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Web_Api_Repository.Models.Domain;
using Web_Api_Repository.Models.DTO;
using Web_Api_Repository.Repository.IService;

namespace Web_Api_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequestDto request)
        {
            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                DOB = request.DOB,
                Password = request.Password,

            };
            await _studentService.CreateAsync(student);
            var response = new StudentDto
            {
                Id = student.Id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                DOB = request.DOB,
                Password = request.Password,

            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var studentsD = await _studentService.GetAllAsync();
            var response = new List<StudentDto>();
            foreach (var students in studentsD)
            {
                response.Add(new StudentDto
                {
                    Id = students.Id,
                    Name = students.Name,
                    Email = students.Email,
                    Phone = students.Phone,
                    Age = students.Age,
                    DOB = students.DOB,
                    Password= students.Password,

                });
            }
            return Ok(response);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var existingStudent = await _studentService.GetById(id);
            if (existingStudent is null)
            {
                return NotFound();
            }
            var response = new StudentDto
            {
                Id = existingStudent.Id,
                Name = existingStudent.Name,
                Email = existingStudent.Email,
                Phone = existingStudent.Phone,
                Age = existingStudent.Age,
                DOB = existingStudent.DOB,
                Password = existingStudent.Password,    


            };
            return Ok(response);
        }
        [HttpPut]
        [Route("{id:int}")] 
        public async Task<IActionResult> EditStudent([FromRoute] int id, UpdateStudentRequestDto request)
        {
            var student5 = new Student
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                DOB = request.DOB,
                Password = request.Password,
            };
            student5 = await _studentService.UpdateAsync(student5);
            if (student5 == null)
            {
                return NotFound();
            }
            var response = new StudentDto
            {
                Id = student5.Id,
                Name = student5.Name,
                Email = student5.Email,
                Phone = student5.Phone,
                Age = student5.Age,
                DOB = student5.DOB,
                Password = student5.Password,
            };
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute]int id)
        {
            var student6=await _studentService.DeleteAsync(id);
            if (student6 == null)
            {
                return NotFound();
            }
            var response = new StudentDto
            {
                Id = student6.Id,
                Name = student6.Name,
                Email = student6.Email,
                Phone = student6.Phone,
                Age = student6.Age,
                DOB = student6.DOB,
                Password = student6.Password,

            };
            return Ok(response);    
            }
    }
}
