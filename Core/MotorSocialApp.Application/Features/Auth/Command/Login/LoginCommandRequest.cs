using MediatR;
using System.ComponentModel;

namespace MotorSocialApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("99harkan@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("Hakan12.")]
        public string Password { get; set; }
    }
}