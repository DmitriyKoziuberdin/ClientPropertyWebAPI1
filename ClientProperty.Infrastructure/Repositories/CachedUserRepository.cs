using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace ClientProperty.Infrastructure.Repositories
{
    public class CachedUserRepository : IUserRepository
    {
        private readonly UserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;
        private static string _cacheKey = "user";

        public CachedUserRepository(UserRepository userRepository, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _memoryCache
                .GetOrCreateAsync(_cacheKey, (entry) => _userRepository.GetAllUsers());
            return users!.ToList();
        }

        public async Task<User> GetUserById(long id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task CreateUser(User user)
        {
            _memoryCache.Remove(_cacheKey);
            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            _memoryCache.Remove(_cacheKey);
            await _userRepository.UpdateUser(user);
        }

        public async Task<int> DeleteUser(long id)
        {
            _memoryCache.Remove(_cacheKey);
            return await _userRepository.DeleteUser(id);
        }
    }
}
