using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{

    public class GroupChatMessage : EntityBase,IEntityBase
    {
        public Guid GroupId { get; set; } // Mesajın ait olduğu grup ID
        public Guid SenderUserId { get; set; } // Mesajı gönderen kullanıcının ID'si
        public string SenderUserName { get; set; } // Mesajı gönderen kullanıcının adı
        public string Content { get; set; } // Mesaj içeriği
        public DateTime SentAt { get; set; } // Mesajın gönderildiği zaman
        
    }
}
