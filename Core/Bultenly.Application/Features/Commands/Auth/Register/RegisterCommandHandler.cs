using Bultenly.Application.DTOs.Auth;
using Bultenly.Application.DTOs.Base;
using Bultenly.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bultenly.Application.Features.Commands.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse<AuthResponseDto>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(
            UserManager<IdentityUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<BaseResponse<AuthResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return BaseResponse<AuthResponseDto>.FailureResult("Bu email adresi zaten kullanılmaktadır.");
            }

            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BaseResponse<AuthResponseDto>.FailureResult("Kayıt işlemi başarısız.", errors);
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await _tokenService.GenerateTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var expiresAt = DateTime.UtcNow.AddMinutes(60);

            var response = new AuthResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = roles.ToList()
                }
            };

            return BaseResponse<AuthResponseDto>.SuccessResult(response, "Kayıt başarılı.");
        }
    }
}
