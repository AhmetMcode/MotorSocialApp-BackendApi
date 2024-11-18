using System;

namespace MotorSocialApp.Application.Features.UserProfile.Exceptions
{
    public class UserProfileNotFoundException : Exception
    {
        public UserProfileNotFoundException(Guid userId)
            : base($"User profile with ID {userId} not found.")
        {
        }
    }
}
