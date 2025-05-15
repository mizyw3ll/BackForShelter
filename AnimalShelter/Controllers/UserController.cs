using AnimalShelter.Data;
using AnimalShelter.Models.Domain.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using AnimalShelter.Models.DTO.Main.User;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AnimalShelterDbContext _dbContext;
        public UserController(AnimalShelterDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // получение всех пользователей
        [HttpGet]
        public IActionResult GetAllUser()
        {
            // получение из бд domain модели
            var usersDomain = _dbContext.User.ToList();

            // приведение domain к dto
            var usersResponse = usersDomain.Select(u => new UserResponse()
            {
                Id = u.Id,
                LastName = u.LastName,
                FirstName = u.FirstName,
                Patronymic = u.Patronymic,
                Phone = u.Phone,
                Email = u.Email,
                Login = u.Login,
                RoleUserId = u.RoleUserId
                
            }).ToList();
            // возвращение dto 

            return Ok(usersResponse);
        }

        // получение конкретного пользователя
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetByIdUser([FromRoute] Guid id)
        {
            var userDomain = _dbContext.User.Find(id);

            //var userDomain = _dbContext.User.FirstOrDefault(x => x.Id == id);

            if (userDomain == null)
                return NotFound(); // 404

            var userResponse = new UserResponse
            {
                Id = userDomain.Id,
                LastName = userDomain.LastName,
                FirstName = userDomain.FirstName,
                Patronymic = userDomain.Patronymic,
                Phone = userDomain.Phone,
                Email = userDomain.Email,
                Login = userDomain.Login,
                RoleUserId = userDomain.RoleUserId
            };

            return Ok(userResponse);
        }


        //создание нового клиента post
        [HttpPost]
        // так как инфа от клиента и это post, поэтому fromBody
        public IActionResult CreateUser([FromBody] UserRequest addUserRequest) 
        {
            // превращение dto в domain
            var userDomain = new User
            {
                LastName = addUserRequest.LastName,
                FirstName = addUserRequest.FirstName,
                Patronymic = addUserRequest.Patronymic,
                Phone = addUserRequest.Phone,
                Email = addUserRequest.Email,
                Login = addUserRequest.Login,
                RoleUserId = addUserRequest.RoleUserId
            };

            _dbContext.User.Add(userDomain);
            _dbContext.SaveChanges();

            // domain обратно в dto
            var userResponse = new UserResponse
            {
                Id = userDomain.Id,
                LastName = userDomain.LastName,
                FirstName = userDomain.FirstName,
                Patronymic = userDomain.Patronymic,
                Phone = userDomain.Phone,
                Email = userDomain.Email,
                Login = userDomain.Login,
                RoleUserId = userDomain.RoleUserId
            };

            //return CreatedAtAction(nameof(GetById), new { id = userDto.Id}, userDto);

            return Ok(userResponse);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserRequest updateUserRequest)
        {
            var userDomain = _dbContext.User.Find(id);
            if (userDomain is null)
                return NotFound();

            userDomain.LastName = updateUserRequest.LastName;
            userDomain.FirstName = updateUserRequest.FirstName;
            userDomain.Patronymic = updateUserRequest.Patronymic;
            userDomain.Phone = updateUserRequest.Phone;
            userDomain.Email = updateUserRequest.Email;
            userDomain.Login = updateUserRequest.Login;
            userDomain.RoleUserId = updateUserRequest.RoleUserId;

            _dbContext.SaveChanges();

            var userResponse = new UserResponse
            {
                Id = userDomain.Id,
                LastName = userDomain.LastName,
                FirstName = userDomain.FirstName,
                Patronymic = userDomain.Patronymic,
                Phone = userDomain.Phone,
                Email = userDomain.Email,
                Login = userDomain.Login,
                RoleUserId = userDomain.RoleUserId
            };

            return Ok(userResponse);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _dbContext.User.Find(id);

            if(user is null)
                return NotFound();

            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
