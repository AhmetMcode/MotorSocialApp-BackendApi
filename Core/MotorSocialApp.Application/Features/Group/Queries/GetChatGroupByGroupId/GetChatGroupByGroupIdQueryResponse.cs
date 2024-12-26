using MotorSocialApp.Application.DTOs;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetChatGroupByGroupId
{
    public class GetChatGroupByGroupIdQueryResponse
    {
        public string Name { get; set; } // Grup adı
        public Guid UniqueId { get; set; } // Grup adı
        public string GroupDescription { get; set; }
        public string GroupIconPath { get; set; }
        public Guid GroupAdminUserId { get; set; }
        public int MaxMemberCount { get; set; }
        public int CurrentMemberCount { get; set; }

        public ICollection<UserChatGroupConnectionUserDto> Users { get; set; } = new List<UserChatGroupConnectionUserDto>();
    }
}
