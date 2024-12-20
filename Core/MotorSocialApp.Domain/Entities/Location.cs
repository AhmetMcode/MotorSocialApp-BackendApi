using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class Location : EntityBase
    {
        public double Latitude { get; set; }    
        public double Longitude { get; set; }
        public string IconPath { get; set; }
        public int IconPrice { get; set; }
        public string MarkerId { get; set; }
        public Guid UserId { get; set; }

        public Location() { }

        public Location(double latitude, double longitude, string iconPath,string markerId, Guid userId, int iconPrice)
        {
            Latitude = latitude;
            Longitude = longitude;
            IconPath = iconPath;
            MarkerId = markerId;
            UserId = userId;
            IconPrice = iconPrice;
        }
    }
}
