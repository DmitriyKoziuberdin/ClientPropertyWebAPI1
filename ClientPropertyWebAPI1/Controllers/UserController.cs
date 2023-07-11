using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientPropertyWebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id:long}")]
        public async Task<UserResponseModel> GetUserById([FromRoute]long id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        public async Task CreateUser(UserRequestModel userRequest)
        {
            await _userService.CreateUser(userRequest);
        }

        [HttpPut]
        public async Task<UserResponseModel> UpdateUser(UserUpdateRequestModel userRequest)
        {
            return await _userService.UpdateUser(userRequest);
        }

        [HttpDelete]
        public async Task DeleteUser(long id)
        {
           await _userService.DeleteUser(id);
        }
    }
}
