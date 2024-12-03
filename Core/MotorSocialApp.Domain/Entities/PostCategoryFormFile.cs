using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class PostCategoryFormFile : EntityBase
    {
        public string PhotoPath { get; set; } = string.Empty; // Fotoğrafın dosya yolu veya URL'i
        public DateTime UploadedDate { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Post> Posts = new List<Post>();
        
    }
}
