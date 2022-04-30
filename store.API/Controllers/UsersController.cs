using store.Domain.Models;
using store.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace store.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, object>>> GetById(int Id)
        {
            Dictionary<string, object> response = new();
            User user = await _usersService.GetUser(Id);
            response.Add("data", user);
            response.Add("message", "success");

            return response;
        }
    }
}