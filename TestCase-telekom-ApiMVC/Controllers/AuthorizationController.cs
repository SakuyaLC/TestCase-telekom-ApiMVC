using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCase_telekom_ApiMVC.Data.Interfaces;
using TestCase_telekom_ApiMVC.Model;

namespace TestCase_telekom_ApiMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IUserRepository _repository;

        public AuthorizationController(IUserRepository repository)
        {
            _repository = repository;
        }

        //Посмотреть всех пользователей
        [HttpGet("/get-users")]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUsers()
        {
            var users = _repository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        //Создать пользователя (пароли шифруются)
        [HttpPost("/create-user")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User user)
        {

            if (_repository.UserExists(user.user_email))
                return BadRequest("Already exists");
            else
            {
                _repository.CreateUser(user);
                return Ok(_repository.GetUsers().Where(u => u.user_email == user.user_email));
            }

        }

        //Метод авторизации
        [HttpPost("/authorize")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Authorize([FromBody] User user)
        {

            if (_repository.Authorize(user.user_email, user.user_password))
                return Ok(_repository.GetUsers().Where(u => u.user_email == user.user_email));
            else
            {
                return BadRequest("Incorrect email or password");
            }

        }



    }
}
