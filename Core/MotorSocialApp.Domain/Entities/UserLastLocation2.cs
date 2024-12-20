using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class UserLastLocation2 : EntityBase
    {
        public UserLastLocation2() { }
        public UserLastLocation2(Guid userId, double lat, double lng)
        {
            UserId = userId;
            Lat = lat;
            Lng = lng;
        }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
