using store.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using store.Service.Service.v1;

namespace store.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly StoreService _storeService;
        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("createstore")]
        public async Task<ActionResult<Dictionary<string, object>>> CreateStore(CreateStoreDto createStoreDto)
        {
            Dictionary<string, object> response = await _storeService.CreateStore(createStoreDto);
            bool error = response.ContainsKey("error");
            ActionResult<Dictionary<string, object>> result = error ? BadRequest(response) : Ok(response);
            return result;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("getstorebyuser")]
        public async Task<ActionResult<Dictionary<string, object>>> GetStoreByUser(int Id)
        {
            Dictionary<string, object> response = await _storeService.GetStoreByUser(Id);
            bool error = response.ContainsKey("error");
            ActionResult<Dictionary<string, object>> result = error ? BadRequest(response) : Ok(response);
            return result;
        }
    }
}