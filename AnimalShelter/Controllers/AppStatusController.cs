using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Dictionary;
using AnimalShelter.Models.DTO.Dictionary.AnimalView;
using AnimalShelter.Models.DTO.Dictionary.AppStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppStatusController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;
        public AppStatusController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // получение всех видов животных

        [HttpGet]
        public IActionResult GetAllAppStatus()
        {
            var appStatusesDomain = _dbContext.AppStatuses.ToList();

            var appStatusesResponse = appStatusesDomain.Select(v => new AppStatusResponse()
            {
                Id = v.Id,
                Title = v.Title
            }).ToList();

            return Ok(appStatusesResponse);
        }

        [HttpPost]
        public IActionResult CreateAppStatus([FromBody] AnimalViewRequest addAppStatusRequest)
        {
            var appStatusesDomain = new AppStatus
            {
                Title = addAppStatusRequest.Title
            };
            _dbContext.AppStatuses.Add(appStatusesDomain);
            _dbContext.SaveChanges();

            var appStatusesResponse = new AppStatusResponse
            {
                Id = appStatusesDomain.Id,
                Title = appStatusesDomain.Title,
            };

            return Ok(appStatusesResponse);
        }
    }
}
