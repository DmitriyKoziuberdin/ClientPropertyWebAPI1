using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain;
using ClientProperty.Domain.Entities;

namespace ClientProperty.ApplicationService.Interfaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllProperties();
        Task<Property> GetPropertyById(long id);
        Task<int> DeleteProperty(long id);
        Task CreateProperty(Property property);
        Task UpdateProperty(Property property);
        Task AddUser(long propertyId, long userId);
        Task<bool> AnyPropertyById(long propertyId);
        Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear();
        Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue();

    }
}

