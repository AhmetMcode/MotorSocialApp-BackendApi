using MediatR;
using System;

namespace MotorSocialApp.Application.Features.Post.Command.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public Guid UserId { get; set; }
        public string PostContentTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }
        public string PostLocation { get; set; }
        public int PostCategoryId { get; set; }
    }
}
