using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerRelationshipFolder
{
    public class UserFollowerRelationshipFolderCommandRequest : IRequest<UserFollowerRelationshipFolderCommandResponse>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedUserId { get; set; }
    }
}
