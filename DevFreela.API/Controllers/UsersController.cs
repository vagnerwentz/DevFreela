using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateUserInputModel createUserInputModel
        )
        {
            var id = _userService.SignUp(createUserInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, createUserInputModel);
        }

        //[HttpPost("{id}")]
        //public IActionResult SignIn(int id, [FromBody] SignInModel signInModel)
        //{
        //    return NoContent();
        //}

    }
}

