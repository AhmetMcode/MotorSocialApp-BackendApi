using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class UserFollower : EntityBase, IEntityBase
    {
        public Guid FollowerId { get; set; }
        public User Follower { get; set; }

        public Guid FollowedUserId { get; set; }
        public User FollowedUser { get; set; }
    }
}
