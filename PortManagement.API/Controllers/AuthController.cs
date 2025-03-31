using Microsoft.AspNetCore.Mvc;
using PortManagement.Application.Interfaces;
using PortManagement.Application.DTOs;
using PortManagement.Domain.Entities;

namespace PortManagement.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDTO request)
        {
            var authResponse = await _authService.AuthenticateAsync(request.Email, request.Password);
            if (authResponse == null)
                return Unauthorized(new { message = "Credenciales incorrectas" });

            return Ok(authResponse);
        }
    }

}
