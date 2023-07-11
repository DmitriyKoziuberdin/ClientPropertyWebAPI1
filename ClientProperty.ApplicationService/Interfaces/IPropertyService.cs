using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;

namespace ClientProperty.ApplicationService.Interfaces
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllProperties();
        Task<PropertyResponseModel> GetPropertyById(long id);//PropertyResponseModel
        Task CreateProperty(PropertyRequestModel propertyRequestModel);//PropertyRequestModel
        Task<PropertyUpdateResponseModel> UpdateProperty(PropertyUpdateRequestModel property);
        Task DeleteProperty(long id);
        Task AddUser(long propertyId, long userId);
        Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth();
        Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear();
        Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue();
    }
}
