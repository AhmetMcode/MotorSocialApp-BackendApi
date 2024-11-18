using MotorSocialApp.Domain.Common;
using System;

namespace MotorSocialApp.Domain.Entities
{
    public class PostLike : EntityBase, IEntityBase
    {
        public int PostId { get; set; } // Beğenilen post
        public Post Post { get; set; } // Post ile ilişki

        public Guid UserId { get; set; } // Beğeniyi yapan kullanıcı
        public User User { get; set; } // Kullanıcı ile ilişki

        public bool IsLike { get; set; } // Beğeni durumu (True: Beğenildi, False: Beğenilmedi)
    }
}
