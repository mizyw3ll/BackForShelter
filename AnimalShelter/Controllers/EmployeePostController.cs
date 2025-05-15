using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.EmployeePost;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePostController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public EmployeePostController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployeePost()
        {
            var employeesPostDomain = _dbContext.EmployeePosts.ToList();

            var employeesPostResponse = employeesPostDomain.Select(e => new EmployeePostResponse()
            {
                Id = e.Id,
                Title = e.Title
            }).ToList();

            return Ok(employeesPostResponse);
        }


        [HttpPost]
        public IActionResult CreateEmployeePost([FromBody] EmployeePostRequest addEmployeePost)
        {
            var employeePostDomain = new EmployeePost
            {
                Title = addEmployeePost.Title
            };

            _dbContext.EmployeePosts.Add(employeePostDomain);
            _dbContext.SaveChanges();

            var employeePostResponse = new EmployeePostResponse()
            {
                Id = employeePostDomain.Id,
                Title = addEmployeePost.Title
            };

            return Ok(employeePostResponse);
        }

    }
}
