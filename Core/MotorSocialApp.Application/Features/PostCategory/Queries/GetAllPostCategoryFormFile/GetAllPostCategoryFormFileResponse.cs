using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile
{
    public class GetAllPostCategoryFormFileResponse
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; } = string.Empty; // Fotoğrafın dosya yolu veya URL'i
        public DateTime UploadedDate { get; set; }
        public string CategoryName { get; set; }
    }
}
