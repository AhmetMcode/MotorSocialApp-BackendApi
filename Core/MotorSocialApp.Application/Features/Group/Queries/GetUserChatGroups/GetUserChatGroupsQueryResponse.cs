using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetUserChatGroups
{
    public class GetUserChatGroupsQueryResponse
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; } // Grup adı
        public string GroupDescription { get; set; }
        public string GroupIconPath { get; set; }
        public Guid GroupAdminUserId { get; set; }
        public User GroupAdmin { get; set; }
        public int MaxMemberCount { get; set; }
        public int CurrentMemberCount { get; set; }
    }
}
