using store.Domain.DTOs;
using store.Service.Service.v1;
using Microsoft.AspNetCore.Mvc;
using store.Domain.Requests;

namespace store.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("login")]
        public async Task<ActionResult<Dictionary<string, object>>> Login(Login login)
        {
            Dictionary<string, object> response = await _usersService.Login(login);
            bool error = response.ContainsKey("error");
            ActionResult<Dictionary<string, object>> result = error ? BadRequest(response) : Ok(response);
            return result;
        }

        [MapToApiVersion("1.0")]
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