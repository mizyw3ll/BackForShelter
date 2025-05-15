using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.AnimalBreed;
using AnimalShelter.Models.DTO.Dictionary.AnimalView;
using AnimalShelter.Models.DTO.Dictionary.EmployeePost;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalBreedController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;

        public AnimalBreedController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAnimalBreed()
        {
            var animalBreedsDomain = _dbContext.AnimalBreeds
                .Include(a => a.AnimalView)
                .ToList();

            var animalBreedsResponse = animalBreedsDomain.Select(b => new AnimalBreedResponse()
            {
                Id = b.Id,
                AnimalViewId = b.AnimalViewId,
                Title = b.Title
            }).ToList();

            return Ok(animalBreedsResponse);
        }

        [HttpPost]
        public IActionResult CreateView([FromBody] AnimalBreedRequest addAnimalBreed)
        {
            // добавление переменной с видом животного - не обязательно
            var animalView = _dbContext.AnimalViews
                .FirstOrDefault(v => v.Id == addAnimalBreed.AnimalViewId);

            if (animalView is null)
                return BadRequest("Указанный AnimalView не существует");


            // добавление самой породы
            var animalBreedDomain = new AnimalBreed
            {
                Title = addAnimalBreed.Title,
                AnimalViewId = addAnimalBreed.AnimalViewId
            };

            _dbContext.AnimalBreeds.Add(animalBreedDomain);
            _dbContext.SaveChanges();

            var animalBreedResponse = new AnimalBreedResponse()
            {
                Id = animalBreedDomain.Id,
                AnimalViewId = animalBreedDomain.AnimalViewId,
                Title = animalBreedDomain.Title,
            };

            return Ok(animalBreedResponse);
        }
    }
}
