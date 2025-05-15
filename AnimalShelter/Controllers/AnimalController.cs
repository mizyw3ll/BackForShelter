using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Main;
using AnimalShelter.Models.DTO.Main.Animal;

//using AnimalShelter.Models.DTO.Main.Animal;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        // Создание методов дейтствий
        private readonly AnimalShelterDbContext _dbContext;

        public AnimalController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAnimal()
        {
            var animalsDomain = _dbContext.Animals.ToList();

            var animalsResponse = animalsDomain.Select(a => new AnimalResponse()
            {
                Id = a.Id,
                AnimalViewId = a.AnimalViewId,
                IsMale = a.IsMale,
                Age = a.Age,
                AnimalBreedId = a.AnimalBreedId,
                DistinctiveFeatures = a.DistinctiveFeatures,
                Weight = a.Weight,
                Height = a.Height,
                Photos = a.Photos,
                AnimalStatusId = a.AnimalStatusId
            }).ToList();

            return Ok(animalsResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdAnimal([FromRoute] Guid id)
        {
            var animalDomain = _dbContext.Animals.Find(id);

            if (animalDomain == null)
                return NotFound();

            var animalResponse = new AnimalResponse
            {
                Id = animalDomain.Id,
                AnimalViewId = animalDomain.AnimalViewId,
                IsMale = animalDomain.IsMale,
                Age = animalDomain.Age,
                AnimalBreedId = animalDomain.AnimalBreedId,
                DistinctiveFeatures = animalDomain.DistinctiveFeatures,
                Weight = animalDomain.Weight,
                Height = animalDomain.Height,
                Photos = animalDomain.Photos,
                AnimalStatusId = animalDomain.AnimalStatusId
            };

            return Ok(animalResponse);
        }


        // добавление животного
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] AnimalRequest addAnimal)
        {
            var animalDomain = new Animal
            {
                AnimalViewId = addAnimal.AnimalViewId,
                IsMale = addAnimal.IsMale,
                Age = addAnimal.Age,
                AnimalBreedId = addAnimal.AnimalBreedId,
                DistinctiveFeatures = addAnimal.DistinctiveFeatures,
                Weight = addAnimal.Weight,
                Height = addAnimal.Height,
                Photos = addAnimal.Photos,
                AnimalStatusId = addAnimal.AnimalStatusId
            };

            _dbContext.Animals.Add(animalDomain);
            _dbContext.SaveChanges();

            var animalResponse = new AnimalResponse
            {
                Id = animalDomain.Id,
                AnimalViewId = animalDomain.AnimalViewId,
                IsMale = animalDomain.IsMale,
                Age = animalDomain.Age,
                AnimalBreedId = animalDomain.AnimalBreedId,
                DistinctiveFeatures = animalDomain.DistinctiveFeatures,
                Weight = animalDomain.Weight,
                Height = animalDomain.Height,
                Photos = animalDomain.Photos,
                AnimalStatusId = animalDomain.AnimalStatusId
            };

            return Ok(animalResponse);
        }

        // редактирование животного

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAnimal(Guid id, AnimalRequest updateAnimal)
        {
            var animalDomain = _dbContext.Animals.Find(id);
            if (animalDomain is null)
                return NotFound();

            animalDomain.AnimalViewId = updateAnimal.AnimalViewId;
            animalDomain.IsMale = updateAnimal.IsMale;
            animalDomain.Age = updateAnimal.Age;
            animalDomain.AnimalBreedId = updateAnimal.AnimalBreedId;
            animalDomain.DistinctiveFeatures = updateAnimal.DistinctiveFeatures;
            animalDomain.Weight = updateAnimal.Weight;
            animalDomain.Height = updateAnimal.Height;
            animalDomain.Photos = updateAnimal.Photos;
            animalDomain.AnimalStatusId = updateAnimal.AnimalStatusId;

            _dbContext.SaveChanges();

            var animalResponse = new AnimalResponse
            {
                Id = animalDomain.Id,
                AnimalViewId = animalDomain.AnimalViewId,
                IsMale = animalDomain.IsMale,
                Age = animalDomain.Age,
                AnimalBreedId = animalDomain.AnimalBreedId,
                DistinctiveFeatures = animalDomain.DistinctiveFeatures,
                Weight = animalDomain.Weight,
                Height = animalDomain.Height,
                Photos = animalDomain.Photos,
                AnimalStatusId = animalDomain.AnimalStatusId
            };

            return Ok(animalResponse);
        }

        // удаление животного
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAnimal(Guid id)
        {
            var animal = _dbContext.Animals.Find(id);

            if(animal is null)
                return NotFound();

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
