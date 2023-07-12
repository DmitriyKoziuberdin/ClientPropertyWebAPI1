using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace ClientProperty.Infrastructure.Repositories
{
    public class CachedPropertyRepository : IPropertyRepository
    {
        private readonly PropertyRepository _propertyRepository;
        private readonly IMemoryCache _memoryCache;
        private static string _cashKey = "property";
        
        public CachedPropertyRepository(PropertyRepository propertyRepository, IMemoryCache memoryCache)
        {
            _propertyRepository = propertyRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<Property>> GetAllProperties()
        {
            var properties = await _memoryCache
                .GetOrCreateAsync(_cashKey, (entry) => _propertyRepository.GetAllProperties());
            return properties!.ToList();
        }

        public async Task<Property> GetPropertyById(long id)
        {
            return await _propertyRepository.GetPropertyById(id);
        }

        public async Task CreateProperty(Property property)
        {
            _memoryCache.Remove(_cashKey);
            await _propertyRepository.CreateProperty(property);
        }

        public async Task AddUser(long propertyId, long userId)
        {
            _memoryCache.Remove(_cashKey);
            await _propertyRepository.AddUser(propertyId, userId);
        }

        public async Task UpdateProperty(Property property)
        {
            _memoryCache.Remove(_cashKey);
            await _propertyRepository.UpdateProperty(property);
        }

        public async Task<int> DeleteProperty(long id)
        {
            _memoryCache.Remove(_cashKey);
            return await _propertyRepository.DeleteProperty(id);
        }

        public async Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue()
        {
            return await _propertyRepository.GetCurrentValue();
        }

        public async Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership()
        {
            return await _propertyRepository.GetDaysOfPropertyOwnership();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth()
        {
           return await _propertyRepository.GetDaysPeriodsCountByMonth();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek()
        {
            return await _propertyRepository.GetDaysPeriodsCountByWeek();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear()
        {
            return await _propertyRepository.GetDaysPeriodsCountByYear();
        }

        public async Task<bool> AnyPropertyById(long propertyId)
        {
            return await _propertyRepository.AnyPropertyById(propertyId);
        }
    }
}
