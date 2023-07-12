using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;
using ClientProperty.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientPropertyWebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        protected readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<List<Property>> GetAllProperties()
        {
            return await _propertyService.GetAllProperties();
        }

        [HttpGet("{id:long}")]
        public async Task<PropertyResponseModel> GetPropertyById([FromRoute] long id)
        {
            return await _propertyService.GetPropertyById(id);
        }

        [HttpPost]
        public async Task CreateProperty(PropertyRequestModel propertyRequestModel)
        {
            await _propertyService.CreateProperty(propertyRequestModel);
        }

        [HttpPut]
        public async Task<PropertyUpdateResponseModel> UpdateProperty([FromBody] PropertyUpdateRequestModel propertyRequestModel)
        {
            return await _propertyService.UpdateProperty(propertyRequestModel);
        }

        [HttpDelete("{categoryId:long}")]
        public async Task DeleteProperty([FromRoute]long categoryId)
        {
            await _propertyService.DeleteProperty(categoryId);
        }

        [HttpPost("{propertyId:long}/user/{userId:long}")]
        public async Task<IActionResult> AddUser([FromRoute]long propertyId, [FromRoute] long userId)
        {
            await _propertyService.AddUser(propertyId, userId);
            return Ok();
        }

        [HttpGet("property/daysOfPropertyOwnership")]
        public async Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership()
        {
            return await _propertyService.GetDaysOfPropertyOwnership();
        }

        [HttpGet("property/daysPeriodsCountByWeek")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek()
        {
            return await _propertyService.GetDaysPeriodsCountByWeek();
        }

        [HttpGet("property/daysPeriodsCountByMonth")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth()
        {
            return await _propertyService.GetDaysPeriodsCountByMonth();
        }

        [HttpGet("property/daysPeriodsCountByYear")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear()
        {
            return await _propertyService.GetDaysPeriodsCountByYear();
        }

        [HttpGet("property/currentValue")]
        public async Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue()
        {
            return await _propertyService.GetCurrentValue();
        }
    }
}
