using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Main.Voluenteer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public VolunteerController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllVoluenteer()
        {
            var volunteersDomain = _dbContext.Volunteers.ToList();

            var volunteersResponse = volunteersDomain.Select(v => new VolunteerResponse()
            {
                Id = v.Id,
                UserId = v.UserId,
                Preferences = v.Preferences,
                MoreInformation = v.MoreInformation
            }).ToList();

            return Ok(volunteersResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var volunteerDomain = _dbContext.Volunteers.Find(id);

            if (volunteerDomain is null)
                return BadRequest("Нет такого волонтера");

            var volunteerResponse = new VolunteerResponse
            {
                Id = volunteerDomain.Id,
                UserId = volunteerDomain.UserId,
                Preferences = volunteerDomain.Preferences,
                MoreInformation = volunteerDomain.MoreInformation
            };

            return Ok(volunteerResponse);
        }

        [HttpPost]
        public IActionResult CreateVoluenteer([FromBody] VolunteerRequest addVolunteerRequest)
        {
            var volunteerDomain = new Volunteer
            {
                UserId = addVolunteerRequest.UserId,
                Preferences = addVolunteerRequest.Preferences,
                MoreInformation = addVolunteerRequest.MoreInformation
            };

            _dbContext.Volunteers.Add(volunteerDomain);
            _dbContext.SaveChanges();

            var volunteerResponse = new VolunteerResponse
            {
                Id = volunteerDomain.Id,
                UserId = volunteerDomain.UserId,
                Preferences = volunteerDomain.Preferences,
                MoreInformation = volunteerDomain.MoreInformation
            };

            return Ok(volunteerResponse);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateVoluenteer(Guid id, [FromBody] VolunteerRequest updateVoluenteerRequest)
        {
            var volunteerDomain = _dbContext.Volunteers.Find(id);

            if (volunteerDomain is null)
                return BadRequest("Нет такого волонтера");

            volunteerDomain.Preferences = updateVoluenteerRequest.Preferences;
            volunteerDomain.MoreInformation = updateVoluenteerRequest.MoreInformation;

            _dbContext.SaveChanges();

            var volunteerResponse = new VolunteerResponse
            {
                Id = volunteerDomain.Id,
                UserId = volunteerDomain.UserId,
                Preferences = volunteerDomain.Preferences,
                MoreInformation = volunteerDomain.MoreInformation
            };

            return Ok(volunteerResponse);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteVoluenteer(Guid id)
        {
            var volunteer = _dbContext.Volunteers.Find(id);

            if (volunteer is null)
                return BadRequest("Нет такого волонтера");

            _dbContext.Volunteers.Remove(volunteer);
            _dbContext.SaveChanges();

            return Ok();
        } 
    }
}
