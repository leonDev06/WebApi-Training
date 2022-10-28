using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sidekick.Training.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task GetUserById()
        {
            Console.WriteLine("GetUserById");
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
