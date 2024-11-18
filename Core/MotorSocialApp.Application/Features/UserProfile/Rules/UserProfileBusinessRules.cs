using MotorSocialApp.Application.Features.UserProfile.Exceptions;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Application.Features.UserProfile.Rules
{
    public class UserProfileBusinessRules
    {
        public void CheckIfUserProfileExists(User user)
        {
            if (user == null)
                throw new UserProfileNotFoundException(Guid.Empty); // Burada gerçek UserId kullanılabilir
        }

        // Diğer iş kuralları burada yer alabilir
    }
}
