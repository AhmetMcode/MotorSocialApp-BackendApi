using MediatR;
using Microsoft.AspNetCore.Http;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UpdateProfile
{
    public class UpdateProfileCommandRequest : IRequest<UpdateProfileCommandResponse>
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
