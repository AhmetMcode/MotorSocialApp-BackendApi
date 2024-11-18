using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class PostCategory : EntityBase, IEntityBase
    {
        public string Name { get; set; } // Kategori adı
        public string IconPath { get; set; } // İkon yolu

        public ICollection<Post> Posts { get; set; } = new List<Post>(); // İlişkili postlar
    }
}
