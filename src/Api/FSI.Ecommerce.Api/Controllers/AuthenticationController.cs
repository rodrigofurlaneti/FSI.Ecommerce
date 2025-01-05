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
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestDto userDto)
        {
            var validadeRequest = ValidateRequest(userDto);

            if (validadeRequest)
            {
                var token = await _service.AuthenticationAsync(userDto);

                if (token.IsAuthentication)
                    return Ok(new { token });
                else
                    return Unauthorized(new { token });
            }
            else
            {
                return Unauthorized("Username or password invalid");
            }
        }

        #region ValidadeRequest

        private bool ValidateRequest(AuthenticationRequestDto userDto)
        {
            if (userDto != null)
            {
                if (userDto.Username != null && userDto.Username != string.Empty)
                {
                    if (userDto.Password != null && userDto.Password != string.Empty)
                    {
                        return true;
                    }
                    else
                    {
                        //"Property password to resquest null and empty";
                        return false;
                    }
                }
                else
                {
                    //"Property username to resquest null and empty";
                    return false;
                }
            }
            else
            {
                //Object resquest null
                return false;
            }
        }

        #endregion
    }
}
