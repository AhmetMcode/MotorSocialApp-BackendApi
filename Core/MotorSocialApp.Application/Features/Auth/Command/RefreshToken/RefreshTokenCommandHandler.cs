﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MotorSocialApp.Application.Bases;
using MotorSocialApp.Application.Features.Auth.Exceptions;
using MotorSocialApp.Application.Features.Auth.Rules;
using MotorSocialApp.Application.Interfaces.Tokens;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;


namespace MotorSocialApp.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommandHandler(IMapper mapper, AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {

                ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
                string email = principal.FindFirstValue(ClaimTypes.Email);

                User? user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı.");
                }

                IList<string> roles = await userManager.GetRolesAsync(user);

                // RefreshToken'ın süresi kontrol ediliyor
                await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

                // Yeni access ve refresh token'ları oluştur
                JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
                string newRefreshToken = tokenService.GenerateRefreshToken();

                // Kullanıcının yeni token bilgilerini güncelle
                user.RefreshToken = newRefreshToken;
                await userManager.UpdateAsync(user);

                return new()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                    RefreshToken = newRefreshToken,
                };
            }

        

    }
}