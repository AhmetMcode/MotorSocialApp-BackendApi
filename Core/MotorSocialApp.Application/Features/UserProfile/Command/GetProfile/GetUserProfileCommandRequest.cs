using MediatR;
using MotorSocialApp.Application.DTOs;

namespace MotorSocialApp.Application.Features.UserProfile.Command.GetProfile
{
    public class GetUserProfileCommandRequest : IRequest<UserProfileDto>
    {
        public Guid UserId { get; set; }
    }
}
