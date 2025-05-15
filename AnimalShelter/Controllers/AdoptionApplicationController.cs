using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Main.AdoptionApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Runtime.CompilerServices;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionApplicationController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public AdoptionApplicationController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAdoptionApplication()
        {
            var adoptionApplicationDomain = _dbContext.AdoptionalApplications.ToList();

            var adoptionApplicationResponse = adoptionApplicationDomain.Select(a => new AdoptionApplicationResponse
            {
                Id = a.Id,
                AnimalId = a.Id,
                UserId = a.Id,
                ApplicationDate = a.ApplicationDate,
                LivingConditions = a.LivingConditions,
                AppStatusId = a.AppStatusId
            }).ToList();

            return Ok(adoptionApplicationResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdAdoptionApplication([FromRoute] Guid id)
        {
            var adoptionApplicationDomain = _dbContext.AdoptionalApplications.Find(id);

            if (adoptionApplicationDomain is null)
                return BadRequest("Нет такой заявки");

            var adoptionApplicationResponse = new AdoptionApplicationResponse
            {
                Id = adoptionApplicationDomain.Id,
                AnimalId = adoptionApplicationDomain.AnimalId,
                UserId = adoptionApplicationDomain.UserId,
                ApplicationDate = adoptionApplicationDomain.ApplicationDate,
                LivingConditions = adoptionApplicationDomain.LivingConditions,
                AppStatusId = adoptionApplicationDomain.AppStatusId
            };

            return Ok(adoptionApplicationResponse);
        }

        [HttpPost]
        public IActionResult CreateAdoptionApplication([FromBody] AdoptionApplicationRequest addAdoptionApplicationRequest)
        {
            var adoptionApplicationDomain = new AdoptionApplication
            {
                AnimalId = addAdoptionApplicationRequest.AnimalId,
                UserId = addAdoptionApplicationRequest.UserId,
                ApplicationDate = addAdoptionApplicationRequest.ApplicationDate,
                LivingConditions = addAdoptionApplicationRequest.LivingConditions,
                AppStatusId = addAdoptionApplicationRequest.AppStatusId
            };

            _dbContext.AdoptionalApplications.Add(adoptionApplicationDomain);
            _dbContext.SaveChanges();

            var adoptionApplication = new AdoptionApplicationResponse
            {
                Id = adoptionApplicationDomain.Id,
                AnimalId = adoptionApplicationDomain.AnimalId,
                UserId = adoptionApplicationDomain.UserId,
                ApplicationDate = adoptionApplicationDomain.ApplicationDate,
                LivingConditions = adoptionApplicationDomain.LivingConditions,
                AppStatusId = adoptionApplicationDomain.AppStatusId
            };

            return Ok(adoptionApplication);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAdoptionApplication(Guid id, [FromBody] AdoptionApplicationRequest updateAdoptionApplicationRequest)
        {
            var adoptionApplicationDomain = _dbContext.AdoptionalApplications.Find(id);

            if (adoptionApplicationDomain is null)
                return BadRequest("Нет такой заявки");

            adoptionApplicationDomain.AnimalId = updateAdoptionApplicationRequest.AnimalId;
            adoptionApplicationDomain.UserId = updateAdoptionApplicationRequest.UserId;
            adoptionApplicationDomain.ApplicationDate = updateAdoptionApplicationRequest.ApplicationDate;
            adoptionApplicationDomain.LivingConditions = updateAdoptionApplicationRequest.LivingConditions;
            adoptionApplicationDomain.AppStatusId = updateAdoptionApplicationRequest.AppStatusId;


            _dbContext.SaveChanges();

            var adoptionApplicationResponse = new AdoptionApplicationResponse
            {
                Id = adoptionApplicationDomain.Id,
                AnimalId = adoptionApplicationDomain.AnimalId,
                UserId = adoptionApplicationDomain.UserId,
                ApplicationDate = adoptionApplicationDomain.ApplicationDate,
                LivingConditions = adoptionApplicationDomain.LivingConditions,
                AppStatusId = adoptionApplicationDomain.AppStatusId
            };

            return Ok(adoptionApplicationResponse);
        }



        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAdoptionApplication(Guid id)
        {
            var adoptionApplication = _dbContext.AdoptionalApplications.Find(id);

            if (adoptionApplication is null)
                return BadRequest("Нет такой заявки");

            _dbContext.AdoptionalApplications.Remove(adoptionApplication);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
