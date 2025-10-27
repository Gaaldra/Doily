using Doily.API.Services.Interfaces;
using Doily.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doily.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserResgistrationDto request)
        {
            await _userService.RegisterUserAsync(request);
            return Created();
        }
    }
}
