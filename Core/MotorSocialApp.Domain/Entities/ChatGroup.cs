using Microsoft.AspNetCore.Identity;
using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class ChatGroup : EntityBase
    {
        public ChatGroup()
        {
        }

        public ChatGroup(Guid uniqueId,string name, string groupDescription, string groupIconPath, Guid groupAdminUserId,int maxMemberCount,int currentMemberCount)
        {
            UniqueId = uniqueId;
            Name = name;
            GroupDescription = groupDescription;
            GroupIconPath = groupIconPath;
            GroupAdminUserId = groupAdminUserId;
            MaxMemberCount = maxMemberCount;
            CurrentMemberCount = currentMemberCount;    
        }

        
        public string Name { get; set; } // Grup adı
        public Guid UniqueId { get; set; } // Grup adı
        public string GroupDescription { get; set; }
        public string GroupIconPath {  get; set; } 
        public Guid GroupAdminUserId { get; set; }
        public int MaxMemberCount { get; set; }
        public int CurrentMemberCount { get; set; }

        public ICollection<UserChatGroupConnection> Users { get; set; } = new List<UserChatGroupConnection>(); 
       
       
    }
}
