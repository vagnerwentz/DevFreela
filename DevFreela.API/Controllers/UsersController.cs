using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateUserModel createUserModel
        )
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }

        [HttpPost("{id}")]
        public IActionResult SignIn(int id, [FromBody] SignInModel signInModel)
        {
            return NoContent();
        }

    }
}

