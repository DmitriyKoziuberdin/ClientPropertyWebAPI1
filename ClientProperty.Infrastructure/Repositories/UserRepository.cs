using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.Domain;
using ClientProperty.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientProperty.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public Task<User> GetUserById(long id)
        {
            return _appDbContext.Users.FirstOrDefaultAsync(userId => userId.Id == id);
        }

        public async Task CreateUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(long id)
        {
            var deletedUser = await _appDbContext.Users.
                Where(userId => userId.Id == id)
                .ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
            return deletedUser;
        }

        public async Task<bool> AnyUserById(long id)
        {
            return await _appDbContext.Users.AnyAsync(userId => userId.Id == id);   
        }

        public async Task<bool> AnyUserWithEmail(string userEmail)
        {
            return await _appDbContext.Users.AnyAsync(email => email.Email == userEmail);
        }
    }
}
