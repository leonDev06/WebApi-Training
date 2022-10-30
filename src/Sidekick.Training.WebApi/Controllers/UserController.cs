using Leon.Sidekicks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sidekick.Training.Model;

namespace Sidekick.Training.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUserById()
        {
            Console.WriteLine("GetUserById");

            return await _userService.GetUserById(1);
        }

        [HttpPost]
        public async Task CreateUserById()
        {
            Console.WriteLine("CreateUser");
        }

        [HttpPut]
        public async Task UpdateUserById()
        {
            Console.WriteLine("UpdateUserById");
        }

        [HttpDelete]
        public async Task DeleteUserById()
        {
            Console.WriteLine("DeleteUserById");
        }
    }
}
