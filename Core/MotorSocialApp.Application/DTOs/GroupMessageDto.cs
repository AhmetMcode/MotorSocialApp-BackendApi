using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.DTOs
{
    public class GroupMessageDto
    {
        public string SenderUserName { get; set; } // Mesajı gönderen kullanıcının adı
        public string Content { get; set; } // Mesaj içeriği
        public DateTime SentAt { get; set; } // Mesajın gönderildiği zaman
    }
}
