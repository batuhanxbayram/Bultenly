using Bultenly.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bultenly.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(IdentityUser user);
        Task<string> GenerateRefreshTokenAsync();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        Task<bool> ValidateTokenAsync(string token);
    }
}
