using Microsoft.AspNetCore.Mvc;
using Sidekick.Training.Model;
using Sidekick.Training.Services;
using Sidekick.Training.WebApi.Models.Request;
using Sidekick.Training.WebApi.Models.Response;

namespace Sidekick.Training.WebApi.Controllers
{
    // The Controller. Controls the services, which will then get data from the providers, whhich will get the data from the database.

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // The service.
        private readonly IUserService _userService;

        // CONSTRUCTORS
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetUserById(int id)
        {
            // Calls service for GetUserById
            User user = await _userService.GetUserById(id);

            // Not found
            if (user == null)
            {
                return NotFound();
            }

            // Display the response returned by the service from the provider.
            // For displaying purposes only.
            GetUserResponse response = new GetUserResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return response;
        }

        // (Tasks below): Same logic as the documented function above (Can be used as reference.)
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateUser([FromBody] CreateUserRequest request)
        {
            // Create new user
            User user = await _userService.CreateUser(request.Name, request.Email);

            CreateUserResponse response = new CreateUserResponse()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return response;
        }

        [HttpPut]
        // Get from body
        public async Task<bool> UpdateUserById([FromBody] CreateUserResponse update)
        {
            // Update user's details
            bool success = await _userService.UpdateUserById(update.Id, update.Name, update.Email);

            return success;
        }

        [HttpDelete]
        [Route("{id}")]
        // Get from route
        public async Task<bool> DeleteUserById(int id)
        {
            // Delete a user.
            bool success = await _userService.DeleteUserById(id);
            return success;
        }
    }
}
