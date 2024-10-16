using MotorSocialApp.Application.Bases;
using MotorSocialApp.Application.Features.Auth.Exceptions;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}