using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain;
using ClientProperty.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientProperty.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        protected readonly AppDbContext _appDbContext;
        public PropertyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _appDbContext.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyById(long id)
        {
            return await _appDbContext.Properties
                .Include(userProperty => userProperty.UserProperties)
                .ThenInclude(user => user.User)
                .FirstOrDefaultAsync(propertyId => propertyId.Id == id);
        }
        public async Task CreateProperty(Property property)
        {
            await _appDbContext.Properties.AddAsync(property);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateProperty(Property property)
        {
            _appDbContext.Properties.Update(property);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProperty(long id)
        {
            var deletedProperty = await _appDbContext.Properties
                .Where(propertyId => propertyId.Id == id)
                .ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
            return deletedProperty;
        }

        public async Task AddUser(long propertyId, long userId)
        {
            _appDbContext.Set<UserProperty>().Add(new UserProperty
            {
                PropertyId = propertyId,
                UserId = userId
            });
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AnyPropertyById(long propertyId)
        {
            return await _appDbContext.Properties.AnyAsync(id => id.Id == propertyId);
        }

        public async Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership()
        {
            var propertyDaysOwned = await _appDbContext.Properties.Select(propertyResponse => new GetDaysOfPropertyOwnershipResponseModel
            {
                Id = propertyResponse.Id,
                Name = propertyResponse.Name,
                DaysOfPropertyOwnership = (DateTimeOffset.UtcNow - propertyResponse.PurchaseDate).Days
            }).ToListAsync();

            return propertyDaysOwned;
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek()
        {
            var period = 7;
            var propertyDaysOwned = await _appDbContext.Properties.Select(propertyResponse => new GetDaysPeriodsCountResponseModel
            {
                Id = propertyResponse.Id,
                Name = propertyResponse.Name,
                PeriodsCount = (DateTimeOffset.UtcNow - propertyResponse.PurchaseDate).Days / period
            }).ToListAsync();
            return propertyDaysOwned;
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth()
        {
            var period = 30;
            var propertyDaysOwned = await _appDbContext.Properties.Select(propertyResponse => new GetDaysPeriodsCountResponseModel
            {
                Id= propertyResponse.Id,
                Name = propertyResponse.Name,
                PeriodsCount = (DateTimeOffset.UtcNow - propertyResponse.PurchaseDate).Days / period
            }).ToListAsync();
            return propertyDaysOwned;
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear()
        {
            var period = 365;
            var propertyDaysOwned = await _appDbContext.Properties.Select(propertyResponse => new GetDaysPeriodsCountResponseModel
            {
                Id= propertyResponse.Id,
                Name = propertyResponse.Name,
                PeriodsCount = (DateTimeOffset.UtcNow - propertyResponse.PurchaseDate).Days / period
            }).ToListAsync();
            return propertyDaysOwned;
        }

        public async Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue()
        {
            var propertyCurrentValue = await _appDbContext.Properties.Select(propertyResponse => new GetCurrentPeriodResponseModel
            {
                Id = propertyResponse.Id,
                Name = propertyResponse.Name,
                CurrentValue = propertyResponse.InitialValue - (propertyResponse.PriceLossSelectedPeriod * (DateTimeOffset.UtcNow - propertyResponse.PurchaseDate).Days)
            }).ToListAsync();
            return propertyCurrentValue;
        }
    }
}
