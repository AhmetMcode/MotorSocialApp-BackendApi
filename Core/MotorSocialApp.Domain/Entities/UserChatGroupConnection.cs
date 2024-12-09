using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class UserChatGroupConnection : EntityBase,IEntityBase
    {
        public UserChatGroupConnection() { }
        public UserChatGroupConnection(Guid chatGroupUniqueId, Guid userId) {
            UserId = userId;
            ChatGroupUniqueId = chatGroupUniqueId;
        }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ChatGroupUniqueId { get; set; }
        public ChatGroup ChatGroup { get; set; }
    }
}
