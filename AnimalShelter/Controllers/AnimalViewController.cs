using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.AnimalView;
using AnimalShelter.Models.DTO.Main.Animal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalViewController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;
        public AnimalViewController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // получение всех видов животных

        [HttpGet]
        public IActionResult GetAllAnimalView()
        {
            var animalViewsDomain = _dbContext.AnimalViews.ToList();

            var animalViewsResponse = animalViewsDomain.Select(v => new AnimalViewResponse()
            {
                Id = v.Id,
                Title = v.Title
            }).ToList();

            return Ok(animalViewsResponse);
        }

        [HttpPost]
        public IActionResult CreateView([FromBody] AnimalViewRequest addAnimalView)
        {
            var animalViewDomain = new AnimalView
            {
                Title = addAnimalView.Title
            };
            _dbContext.AnimalViews.Add(animalViewDomain);
            _dbContext.SaveChanges();

            var animalViewResponse = new AnimalViewResponse
            {
                Id = animalViewDomain.Id,
                Title = animalViewDomain.Title,
            };
            
            return Ok(animalViewResponse);
        }
        
        
    }
}
