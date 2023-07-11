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
        public async Task<PropertyUpdateResponseModel> UpdateProperty(PropertyUpdateRequestModel propertyRequestModel)
        {
            return await _propertyService.UpdateProperty(propertyRequestModel);
        }

        [HttpDelete]
        public async Task DeleteProperty(long id)
        {
            await _propertyService.DeleteProperty(id);
        }

        [HttpPost("{propertyId:long}/user/{userId:long}")]
        public async Task<IActionResult> AddUser([FromRoute]long propertyId, [FromRoute] long userId)
        {
            await _propertyService.AddUser(propertyId, userId);
            return Ok();
        }

        [HttpGet("daysOfPropertyOwnership")]
        public async Task<IEnumerable<GetDaysOfPropertyOwnershipResponseModel>> GetDaysOfPropertyOwnership()
        {
            return await _propertyService.GetDaysOfPropertyOwnership();
        }

        [HttpGet("daysPeriodsCountByWeek")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByWeek()
        {
            return await _propertyService.GetDaysPeriodsCountByWeek();
        }

        [HttpGet("daysPeriodsCountByMonth")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByMonth()
        {
            return await _propertyService.GetDaysPeriodsCountByMonth();
        }

        [HttpGet("daysPeriodsCountByYear")]
        public async Task<IEnumerable<GetDaysPeriodsCountResponseModel>> GetDaysPeriodsCountByYear()
        {
            return await _propertyService.GetDaysPeriodsCountByYear();
        }

        [HttpGet("currentValue")]
        public async Task<IEnumerable<GetCurrentPeriodResponseModel>> GetCurrentValue()
        {
            return await _propertyService.GetCurrentValue();
        }
    }
}
