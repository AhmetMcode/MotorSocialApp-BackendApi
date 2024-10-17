using MotorSocialApp.Application.Bases;

namespace MotorSocialApp.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") { }
    }

    public class UserNotExistException : Exception
    {
        public UserNotExistException() : base("Böyle bir kullanıcı bulunamadı.")
        {
        }
    }
}
