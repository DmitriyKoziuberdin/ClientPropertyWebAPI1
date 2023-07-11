using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;

namespace ClientProperty.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<UserResponseModel> GetUserById(long id);
        Task CreateUser(UserRequestModel user);
        Task<UserResponseModel> UpdateUser(UserUpdateRequestModel user);
        Task DeleteUser(long id);
    }
}
