using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Main.Adoption;
using AnimalShelter.Models.DTO.Main.AdoptionApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public AdoptionController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAdoption()
        {
            var adoptionsDomain = _dbContext.Adoptions.ToList();

            var adoptionsResponse = adoptionsDomain.Select(a => new AdoptionResponse
            {
                Id = a.Id,
                EmployeeId = a.EmployeeId,
                AdoptionDate = a.AdoptionDate,
                IsAdoption = a.IsAdoption,
                ContractNumber = a.ContractNumber,
                AdoptionApplicationId = a.AdoptionApplicationId
            }).ToList();

            return Ok(adoptionsResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdAdoption([FromRoute] Guid id)
        {
            var adoptionDomain = _dbContext.Adoptions.Find(id);

            if (adoptionDomain is null)
                return BadRequest("Нет такой заявки");

            var adoptionResponse = new AdoptionResponse
            {
                Id = adoptionDomain.Id,
                EmployeeId = adoptionDomain.EmployeeId,
                AdoptionDate = adoptionDomain.AdoptionDate,
                IsAdoption = adoptionDomain.IsAdoption,
                ContractNumber = adoptionDomain.ContractNumber,
                AdoptionApplicationId = adoptionDomain.AdoptionApplicationId
            };

            return Ok(adoptionResponse);
        }

        [HttpPost]
        public IActionResult CreateAdoption([FromBody] AdoptionRequest addAdoptionRequest)
        {
            var adoptionDomain = new Adoption
            {
                EmployeeId = addAdoptionRequest.EmployeeId,
                AdoptionDate = addAdoptionRequest.AdoptionDate,
                IsAdoption = addAdoptionRequest.IsAdoption,
                ContractNumber = addAdoptionRequest.ContractNumber,
                AdoptionApplicationId = addAdoptionRequest.AdoptionApplicationId
            };

            _dbContext.Adoptions.Add(adoptionDomain);
            _dbContext.SaveChanges();

            var adoptionApplication = new AdoptionResponse
            {
                Id = adoptionDomain.Id,
                EmployeeId = adoptionDomain.EmployeeId,
                AdoptionDate = adoptionDomain.AdoptionDate,
                IsAdoption = adoptionDomain.IsAdoption,
                ContractNumber = adoptionDomain.ContractNumber,
                AdoptionApplicationId = adoptionDomain.AdoptionApplicationId
            };

            return Ok(adoptionApplication);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAdoption(Guid id, [FromBody] AdoptionRequest updateAdoptionRequest)
        {
            var adoptionDomain = _dbContext.Adoptions.Find(id);

            if (adoptionDomain is null)
                return BadRequest("Нет такой заявки");

            adoptionDomain.EmployeeId = updateAdoptionRequest.EmployeeId;
            adoptionDomain.AdoptionDate = updateAdoptionRequest.AdoptionDate;
            adoptionDomain.IsAdoption = updateAdoptionRequest.IsAdoption;
            adoptionDomain.ContractNumber = updateAdoptionRequest.ContractNumber;
            adoptionDomain.AdoptionApplicationId = updateAdoptionRequest.AdoptionApplicationId;
            _dbContext.SaveChanges();

            var adoptionResponse = new AdoptionResponse
            {
                Id = adoptionDomain.Id,
                EmployeeId = adoptionDomain.EmployeeId,
                AdoptionDate = adoptionDomain.AdoptionDate,
                IsAdoption = adoptionDomain.IsAdoption,
                ContractNumber = adoptionDomain.ContractNumber,
                AdoptionApplicationId = adoptionDomain.AdoptionApplicationId
            };
            return Ok(adoptionResponse);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAdoption(Guid id)
        {
            var adoption = _dbContext.Adoptions.Find(id);

            if (adoption is null)
                return BadRequest("Нет такой заявки");

            _dbContext.Adoptions.Remove(adoption);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
