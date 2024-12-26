using MediatR;
using System.ComponentModel;

namespace MotorSocialApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("99harkan@gmail.com")]
        public string? Email { get; set; }
        [DefaultValue("Confidence99.")]
        public string? Password { get; set; }
    }
}