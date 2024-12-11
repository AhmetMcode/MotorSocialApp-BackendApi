using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class CustomLocationIcon : EntityBase

    {
        public string IconPath { get; set; } = string.Empty; // Fotoğrafın dosya yolu veya URL'i
        public DateTime UploadedDate { get; set; }
        public string IconName { get; set; }
        public int Price { get; set; }

    }
}