using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class UserPhoto : EntityBase, IEntityBase
    {
        public string PhotoPath { get; set; } = string.Empty; // Fotoğrafın dosya yolu veya URL'i
        public DateTime UploadedDate { get; set; }

        // İlişki
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
