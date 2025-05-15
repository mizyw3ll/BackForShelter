using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Main.Employee;
using AnimalShelter.Models.DTO.Main.TemporaryPlacement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryPlacementController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public TemporaryPlacementController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTemporeryPlacement()
        {
            var temporeryPlacementsDomain = _dbContext.TemporaryPlacement.ToList();

            var temporeryPlacementsResponse = temporeryPlacementsDomain
                .Select(t => new TemporaryPlacementResponse
                {
                    Id = t.Id,
                    VoluenteerId = t.VolunteerId,
                    AnimalId = t.AnimalId,
                    DateAnimalTake = t.DateAnimalTake,
                    DateAnimalReturn = t.DateAnimalReturn
                }).ToList();

            return Ok(temporeryPlacementsResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdTemporeryPlacement([FromRoute] Guid id)
        {
            var temporaryPlacementDomain = _dbContext.TemporaryPlacement.Find(id);

            if (temporaryPlacementDomain is null)
                return BadRequest("Нет такого крч");

            var temporeryPlacementsResponse = new TemporaryPlacementResponse
            {
                Id = temporaryPlacementDomain.Id,
                VoluenteerId = temporaryPlacementDomain.VolunteerId,
                AnimalId = temporaryPlacementDomain.AnimalId,
                DateAnimalTake = temporaryPlacementDomain.DateAnimalTake,
                DateAnimalReturn = temporaryPlacementDomain.DateAnimalReturn
            };

            return Ok(temporeryPlacementsResponse);
        }

        [HttpPost]
        public IActionResult CreateTemporaryPlacement([FromBody] TemporaryPlacementRequest addTemporaryPlacementRequest)
        {



            var temporaryPlacementDomain = new TemporaryPlacement
            {
                VolunteerId = addTemporaryPlacementRequest.VoluenteerId,
                AnimalId = addTemporaryPlacementRequest.AnimalId,
                DateAnimalTake = addTemporaryPlacementRequest.DateAnimalTake,
                DateAnimalReturn = addTemporaryPlacementRequest.DateAnimalReturn
            };

            _dbContext.TemporaryPlacement.Add(temporaryPlacementDomain);
            _dbContext.SaveChanges();

            var temporaryPlacementResponse = new TemporaryPlacementResponse
            {
                Id = temporaryPlacementDomain.Id,
                VoluenteerId = temporaryPlacementDomain.VolunteerId,
                AnimalId = temporaryPlacementDomain.AnimalId,
                DateAnimalTake = temporaryPlacementDomain.DateAnimalTake,
                DateAnimalReturn = temporaryPlacementDomain.DateAnimalReturn
            };

            return Ok(temporaryPlacementResponse);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateTemporaryPlacement(Guid id, [FromBody] TemporaryPlacementRequest updateTemporaryPlacementRequest)
        {
            var temporaryPlacementDomain = _dbContext.TemporaryPlacement.Find(id);

            if (temporaryPlacementDomain is null)
                return BadRequest("Нет такого крч");

            temporaryPlacementDomain.VolunteerId = updateTemporaryPlacementRequest.VoluenteerId;
            temporaryPlacementDomain.AnimalId = updateTemporaryPlacementRequest.AnimalId;
            temporaryPlacementDomain.DateAnimalTake = updateTemporaryPlacementRequest.DateAnimalTake;
            temporaryPlacementDomain.DateAnimalReturn = updateTemporaryPlacementRequest.DateAnimalReturn;

            _dbContext.SaveChanges();

            var temploraryPlacementResponse = new TemporaryPlacementResponse
            {
                Id = temporaryPlacementDomain.Id,
                VoluenteerId = temporaryPlacementDomain.VolunteerId,
                AnimalId = temporaryPlacementDomain.AnimalId,
                DateAnimalTake = temporaryPlacementDomain.DateAnimalTake,
                DateAnimalReturn = temporaryPlacementDomain.DateAnimalReturn
            };

            return Ok(temploraryPlacementResponse);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteTemplatePlacement(Guid id)
        {
            var temporaryPlacementDomain = _dbContext.TemporaryPlacement.Find(id);

            if (temporaryPlacementDomain is null)
                return BadRequest("Нет такого крч");

            _dbContext.TemporaryPlacement.Remove(temporaryPlacementDomain);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
