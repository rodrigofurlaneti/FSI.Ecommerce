using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FSI.Ecommerce.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _service;

        public AuthenticationController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("api/Authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationRequestDto userDto)
        {
            var token = await _service.AuthenticationAsync(userDto);

            if (token.IsAuthentication)
                return Ok(new { token });
            else
                return Unauthorized(new { token });
        }
    }
}
