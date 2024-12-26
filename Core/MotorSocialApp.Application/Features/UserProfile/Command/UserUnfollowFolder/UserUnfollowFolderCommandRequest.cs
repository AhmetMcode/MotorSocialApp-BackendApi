using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserUnfollowFolder
{
  

    public class UserUnfollowFolderCommandRequest : IRequest
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedUserId { get; set; }

    }
}
