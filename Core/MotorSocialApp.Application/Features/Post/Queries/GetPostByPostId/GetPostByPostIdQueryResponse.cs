using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetPostByPostId
{
    public class GetPostByPostIdQueryResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } // Post'u oluşturan kullanıcı
        public User User { get; set; } // Kullanıcı ile ilişki

        public string PostContentTitle { get; set; } // Post başlığı
        public string PostContent { get; set; } // Post içeriği
        public DateTime PostDate { get; set; } // Yayınlanma tarihi
        public string PostLocation { get; set; } // Konum bilgisi

        public int PostCategoryId { get; set; } // Kategori ID'si
        public PostCategoryFormFile PostCategory { get; set; } // Kategori ile ilişki

        public string UserPhotoPath { get; set; }
        public string UserFullName { get; set; }
        public string PostCategoryIconPath { get; set; }
        public string PostCategoryName { get; set; }

    }
}
