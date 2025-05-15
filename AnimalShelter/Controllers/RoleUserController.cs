using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.EmployeePost;
using AnimalShelter.Models.DTO.Dictionary.RoleUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public RoleUserController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRoleUser()
        {
            var roleDomain = _dbContext.RoleUsers.ToList();

            var roleResponse = roleDomain.Select(e => new RoleUserResponse()
            {
                Id = e.Id,
                Title = e.Title
            }).ToList();

            return Ok(roleResponse);
        }


        [HttpPost]
        public IActionResult CreateEmployeePost([FromBody] RoleUserRequest addRoleUserRequest)
        {
            var roleDomain = new RoleUser
            {
                Title = addRoleUserRequest.Title
            };

            _dbContext.RoleUsers.Add(roleDomain);
            _dbContext.SaveChanges();

            var roleResponse = new RoleUserResponse()
            {
                Id = roleDomain.Id,
                Title = roleDomain.Title
            };

            return Ok(roleResponse);
        }
    }
}
