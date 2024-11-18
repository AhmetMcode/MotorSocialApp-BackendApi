using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace MotorSocialApp.Domain.Entities
{
    public class Post : EntityBase, IEntityBase
    {
        public Guid UserId { get; set; } // Post'u oluşturan kullanıcı
        public User User { get; set; } // Kullanıcı ile ilişki

        public string PostContentTitle { get; set; } // Post başlığı
        public string PostContent { get; set; } // Post içeriği
        public DateTime PostDate { get; set; } // Yayınlanma tarihi
        public string PostLocation { get; set; } // Konum bilgisi

        public int PostCategoryId { get; set; } // Kategori ID'si
        public PostCategory PostCategory { get; set; } // Kategori ile ilişki

        public ICollection<PostComment> Comments { get; set; } = new List<PostComment>(); // Yorumlar
        public ICollection<PostLike> Likes { get; set; } = new List<PostLike>(); // Beğeniler
    }
}
