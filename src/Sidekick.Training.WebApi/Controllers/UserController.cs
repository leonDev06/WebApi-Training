using Microsoft.AspNetCore.Mvc;
using Sidekick.Training.Services;
using Sidekick.Training.WebApi.Models.Request;
using Sidekick.Training.WebApi.Models.Response;

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
        public async Task<ActionResult<GetUserResponse>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            var response = new GetUserResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = await _userService.CreateUser(request.Name, request.Email);

            var response = new CreateUserResponse()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return response;
        }

        [HttpPut]
        public async Task<bool> UpdateUserById([FromBody] CreateUserResponse update)
        {
            var success = await _userService.UpdateUserById(update.Id, update.Name, update.Email);

            return success;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteUserById(int id)
        {
            var success = await _userService.DeleteUserById(id);
            return success;
        }
    }
}
