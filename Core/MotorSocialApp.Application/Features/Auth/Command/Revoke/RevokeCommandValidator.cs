using FluentValidation;
using MotorSocialApp.Application.Features.Auth.Command.Revoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}