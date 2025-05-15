using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.AnimalStatus;
using AnimalShelter.Models.DTO.Dictionary.AnimalView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalStatusController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;
        public AnimalStatusController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // получение всех статусов животных

        [HttpGet]
        public IActionResult GetAllAnimalStatus()
        {
            var animalStatusesDomain = _dbContext.AnimalStatuses.ToList();

            var animalStatusesResponse = animalStatusesDomain.Select(s => new AnimalStatusResponse()
            {
                Id = s.Id,
                Title = s.Title
            }).ToList(); 

            return Ok(animalStatusesResponse);
        }

        [HttpPost]
        public IActionResult CreateView([FromBody] AnimalStatusRequest addAnimalStatus)
        {
            var animalStatusDomain = new AnimalStatus
            {
                Title = addAnimalStatus.Title
            };
            _dbContext.AnimalStatuses.Add(animalStatusDomain);
            _dbContext.SaveChanges();

            var animalStatusResponse = new AnimalViewResponse
            {
                Id = animalStatusDomain.Id,
                Title = animalStatusDomain.Title,
            };

            return Ok(animalStatusResponse);
        }
    }
}
