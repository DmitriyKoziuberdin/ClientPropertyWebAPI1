using ClientProperty.Domain.Entities;

namespace ClientProperty.ApplicationService.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(long id);
        Task<int> DeleteUser(long id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
    }
}
