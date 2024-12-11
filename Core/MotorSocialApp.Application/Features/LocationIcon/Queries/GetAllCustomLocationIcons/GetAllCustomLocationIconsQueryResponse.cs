using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons
{
    public class GetAllCustomLocationIconsQueryResponse
    {
        public int Id { get; set; }
        public string IconPath { get; set; } = string.Empty; // Fotoğrafın dosya yolu veya URL'i
        public DateTime UploadedDate { get; set; }
        public string IconName { get; set; }
        public int Price { get; set; }
    }
}
