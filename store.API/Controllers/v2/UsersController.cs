using store.Domain.DTOs;
using store.Service.Service.v2;
using Microsoft.AspNetCore.Mvc;

namespace store.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [MapToApiVersion("2.0")]
        [HttpPost("registration")]
        public async Task<ActionResult<Dictionary<string, object>>> Registration(UserDto userDto)
        {
            Dictionary<string, object> response = await _usersService.Registration(userDto);
            bool error = response.ContainsKey("error");
            ActionResult<Dictionary<string, object>> result = error ? BadRequest(response) : Ok(response);
            return result;
        }
    }
}