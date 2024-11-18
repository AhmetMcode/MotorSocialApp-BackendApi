using MotorSocialApp.Application.Bases;


namespace MotorSocialApp.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Email veya şifre yanlış.") { }
    }
}
