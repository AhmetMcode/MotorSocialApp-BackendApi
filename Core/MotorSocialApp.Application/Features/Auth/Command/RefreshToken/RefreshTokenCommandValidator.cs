using FluentValidation;
using MotorSocialApp.Application.Features.Auth.Command.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();

            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}