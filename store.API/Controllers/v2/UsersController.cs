using store.Domain.DTOs;
using store.Domain.Models;
using store.Service.Service;
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
        [HttpGet]
        public async Task<ActionResult<Dictionary<string, object>>> GetById(int Id)
        {
            Dictionary<string, object> response = new();
            User user = await _usersService.GetUser(Id);
            response.Add("data", user);
            response.Add("message", "success");

            return response;
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