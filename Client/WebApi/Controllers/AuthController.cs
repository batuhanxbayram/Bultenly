using Bultenly.Application.DTOs.Auth;
using Bultenly.Application.DTOs.Base;
using Bultenly.Application.Features.Commands.Auth.Login;
using Bultenly.Application.Features.Commands.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<AuthResponseDto>>> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<BaseResponse<AuthResponseDto>>> Register([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<bool>>> Logout()
        {
            // Token blacklisting logic burada implement edilebilir
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(BaseResponse<bool>.SuccessResult(true, "Çıkış başarılı."));
        }

        
    }
}
