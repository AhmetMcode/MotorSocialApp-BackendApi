using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class AppMarkerIconToken : EntityBase , IEntityBase
    {
        //satın alımlar için ayrı bir entity oluşturalacak bu entity kullanıcıya ait toplam tokeni belli edecek.
        public Guid UserId { get; set; }
        public int TotalToken { get; set; }

        //buraya satın alım entitysi listesi gelecek
        //ICollection<SatınAlımEntitysi> asdasd {  get; set; }

        //buraya ise uygulamada hangi markelerın alındığını gösteren liste gelecek.
        //Collection<Location> 
    }
}
