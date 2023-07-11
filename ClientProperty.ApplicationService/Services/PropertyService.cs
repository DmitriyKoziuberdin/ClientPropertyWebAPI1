using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;

namespace ClientProperty.ApplicationService.Services
{
    public class PropertyService : IPropertyService
    {
        protected readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _propertyRepository.GetAllProperties();
        }

        public async Task<PropertyResponseModel> GetPropertyById(long id)
        {
            var propertyById = await _propertyRepository.GetPropertyById(id);
            var propertyResponse = new PropertyResponseModel
            {
                Id = propertyById.Id,
                Name = propertyById.Name,
                TypeOfProperty = propertyById.TypeOfProperty,
                PurchaseDate = propertyById.PurchaseDate,
                InitialValue = propertyById.InitialValue,
                PriceLossSelectedPeriod = propertyById.PriceLossSelectedPeriod,
                Users = propertyById.UserProperties.Select(user => new UserPropertyResponseModel
                {
                    Id = user.UserId,
                    Name = user.User.Name,
                    Address = user.User.Address,
                    Telephone = user.User.Telephone,
                    Email = user.User.Email,
                }).ToList()
            };

            return propertyResponse;
        }

        public async Task CreateProperty(PropertyRequestModel propertyRequestModel)
        {
            await _propertyRepository.CreateProperty(new Property
            {
                Name = propertyRequestModel.Name,
                TypeOfProperty = propertyRequestModel.TypeOfProperty,
                PurchaseDate = propertyRequestModel.PurchaseDate,
                InitialValue = propertyRequestModel.InitialValue,
                PriceLossSelectedPeriod = propertyRequestModel.PriceLossSelectedPeriod
            });
        }

        public async Task<PropertyUpdateResponseModel> UpdateProperty(PropertyUpdateRequestModel propertyRequestModel)
        {
            var property = new Property
            {
                Id = propertyRequestModel.Id,
                Name = propertyRequestModel.Name,
                TypeOfProperty = propertyRequestModel.TypeOfProperty,
                PurchaseDate = propertyRequestModel.PurchaseDate,
                InitialValue = propertyRequestModel.InitialValue,
                PriceLossSelectedPeriod = propertyRequestModel.PriceLossSelectedPeriod
            };
            await _propertyRepository.UpdateProperty(property);
            var propertyResponse = await _propertyRepository.GetPropertyById(property.Id);
            return new PropertyUpdateResponseModel
            {
                Id = propertyResponse.Id,
                Name = propertyResponse.Name,
                TypeOfProperty = propertyResponse.TypeOfProperty,
                PurchaseDate = propertyResponse.PurchaseDate,
                InitialValue = propertyResponse.InitialValue,
                PriceLossSelectedPeriod = propertyResponse.PriceLossSelectedPeriod
            };
        }

        public async Task DeleteProperty(long id)
        {
            await _propertyRepository.DeleteProperty(id);
        }

        public async Task AddUser(long propertyId, long userId)
        {
            await _propertyRepository.AddUser(propertyId, userId);
        }

        public async Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership()
        {
            return await _propertyRepository.GetDaysOfPropertyOwnership();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek()
        {
            return await _propertyRepository.GetDaysPeriodsCountByWeek();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth()
        {
            return await _propertyRepository.GetDaysPeriodsCountByMonth();
        }

        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear()
        {
            return await _propertyRepository.GetDaysPeriodsCountByYear();
        }

        public async Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue()
        {
            return await _propertyRepository.GetCurrentValue();
        }
    }
}
