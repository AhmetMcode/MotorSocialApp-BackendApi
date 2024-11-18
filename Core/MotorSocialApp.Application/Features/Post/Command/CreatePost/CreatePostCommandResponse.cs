using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Command.CreatePost
{
    public class CreatePostCommandResponse
    {
        public int PostId { get; set; }
        public string Message { get; set; }
    }
}
