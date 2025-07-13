using Bultenly.Application.DTOs.Auth;
using Bultenly.Application.DTOs.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bultenly.Application.Features.Commands.Auth.Login
{
    public class LoginCommand : IRequest<BaseResponse<AuthResponseDto>>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
