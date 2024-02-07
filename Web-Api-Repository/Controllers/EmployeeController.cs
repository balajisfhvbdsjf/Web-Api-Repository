using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Repository.Models.Domain;
using Web_Api_Repository.Models.DTO;
using Web_Api_Repository.Repository.IService;

namespace Web_Api_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] UpdateEmployeeRequestDto request)
        {
            if (request.Rating < 0 || request.Rating > 4)
            {
                return BadRequest("Rating should be in the range of 0 to 4.");
            }

            var emploee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Position = request.Position,
                Phone = request.Phone,
                DOB = request.DOB,
                Rating = request.Rating,
                

            };
            await _employeeService.CreateAsync(emploee);
            var response = new EmployeeDto
            {
                Id = emploee.Id,
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Position = request.Position,
                Phone = request.Phone,
                DOB = request.DOB,
                Rating = emploee.Rating

            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
         {
            var employee = await _employeeService.GetAllAsync();
            var response = new List<EmployeeDto>();
            foreach (var employes in employee)
            {
                response.Add(new EmployeeDto
                {
                    Id = employes.Id,
                    Name = employes.Name,
                    Email = employes.Email,
                    Address = employes.Address,
                    Position = employes.Position,
                    Phone = employes.Phone,
                    DOB = employes.DOB,
                    Rating = employes.Rating,
                });
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var existingEmployee=await _employeeService.GetById( id);
            if (existingEmployee==null)
            {
                return BadRequest();
            }
            var response = new EmployeeDto
            {
                Id= existingEmployee.Id,
                Name = existingEmployee.Name,
                Email = existingEmployee.Email,
                Address = existingEmployee.Address,
                Position = existingEmployee.Position,
                Phone = existingEmployee.Phone,
                DOB = existingEmployee.DOB,
                Rating = existingEmployee.Rating,

            };
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id, UpdateEmployeeRequestDto request)
        {
            var employee6 = new Employee
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Position = request.Position,
                Phone = request.Phone,
                DOB = request.DOB,
                Rating = request.Rating,

            };
            employee6 = await _employeeService.UpdateAsync(employee6);
            if (employee6 == null)
            {
                return NotFound();
            }
            var response = new EmployeeDto
            {
                Id = employee6.Id,
                Name = employee6.Name,
                Email = employee6.Email,
                Address = employee6.Address,
                Position = employee6.Position,
                Phone = employee6.Phone,
                DOB = employee6.DOB,
                Rating = employee6.Rating,
            };
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]Guid id)
        {
            var employee=await _employeeService.DeleteAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var response = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                Position = employee.Position,
                Phone = employee.Phone,
                Rating = employee.Rating,

            };
            return Ok(response);
        }

    }
}
