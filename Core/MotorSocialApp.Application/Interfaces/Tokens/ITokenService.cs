using MotorSocialApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace MotorSocialApp.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken();
    }
}
