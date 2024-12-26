using MediatR;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerFolder
{
    public class UserFollowerFolderCommandRequest : IRequest
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedUserId { get; set; }
     
    }
}
