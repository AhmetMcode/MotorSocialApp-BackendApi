using MotorSocialApp.Domain.Common;
using System;

namespace MotorSocialApp.Domain.Entities
{
    public class PostComment : EntityBase, IEntityBase
    {
        public int PostId { get; set; } // Yorumun ait olduğu post
        public Post Post { get; set; } // Post ile ilişki

        public Guid UserId { get; set; } // Yorumu yapan kullanıcı
        public User User { get; set; } // Kullanıcı ile ilişki

        public string Content { get; set; } // Yorum içeriği
        public DateTime CommentDate { get; set; } = DateTime.UtcNow; // Yorum tarihi
    }
}
