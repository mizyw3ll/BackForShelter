using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Dictionary.EmployeePost;
using AnimalShelter.Models.DTO.Main.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public EmployeeController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employeesDomain = _dbContext.Employees.ToList();

            var employeesResponse = employeesDomain.Select(e => new EmployeeResponse
            {
                Id = e.Id,
                UserId = e.UserId,
                EmployeePostId = e.EmployeePostId,
                HireDate = e.HireDate,
                IsAdmin = e.IsAdmin
            }).ToList();

            return Ok(employeesResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdEmployee(Guid id)
        {
            var employeeDomain = _dbContext.Employees.Find(id);

            if (employeeDomain is null)
                return BadRequest("Такой работник не зарегистрирован");

            var employeeResponse = new EmployeeResponse
            {
                Id = employeeDomain.Id,
                UserId = employeeDomain.UserId,
                EmployeePostId = employeeDomain.EmployeePostId,
                HireDate = employeeDomain.HireDate,
                IsAdmin = employeeDomain.IsAdmin
            };

            return Ok(employeeResponse);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeRequest addEmployeeRequest)
        {
            var employeeDomain = new Employee
            {
                UserId = addEmployeeRequest.UserId,
                EmployeePostId = addEmployeeRequest.EmployeePostId,
                HireDate = addEmployeeRequest.HireDate,
                IsAdmin = addEmployeeRequest.IsAdmin
            };

            _dbContext.Employees.Add(employeeDomain);
            _dbContext.SaveChanges();

            var employeeResponse = new EmployeeResponse
            {
                Id = employeeDomain.Id,
                UserId = employeeDomain.UserId,
                EmployeePostId = employeeDomain.EmployeePostId,
                HireDate = employeeDomain.HireDate,
                IsAdmin = employeeDomain.IsAdmin
            };
            return Ok(employeeResponse);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Updateemployee(Guid id, [FromBody] EmployeeRequest updateEmployeeRequest)
        {
            var employeeDomain = _dbContext.Employees.Find(id);

            if (employeeDomain == null)
                return BadRequest("Такой работник не зарегистрирован");

            employeeDomain.UserId = updateEmployeeRequest.UserId;
            employeeDomain.EmployeePostId = updateEmployeeRequest.EmployeePostId;
            employeeDomain.HireDate = updateEmployeeRequest.HireDate;
            employeeDomain.IsAdmin = updateEmployeeRequest.IsAdmin;

            _dbContext.SaveChanges();

            var employeeResponse = new EmployeeResponse
            {
                Id = employeeDomain.Id,
                UserId = employeeDomain.UserId,
                EmployeePostId = employeeDomain.EmployeePostId,
                HireDate = employeeDomain.HireDate,
                IsAdmin = employeeDomain.IsAdmin
            };

            return Ok(employeeResponse);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee is null)
                return BadRequest("Такой работник не зарегистрирован");

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
