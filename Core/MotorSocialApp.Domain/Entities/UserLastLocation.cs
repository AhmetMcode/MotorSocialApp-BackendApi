using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class AddressComponent 
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public List<string> Types { get; set; }
    }

    public class UserLastLocationValues 
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Viewport
    {
        public UserLastLocationValues Northeast { get; set; }
        public UserLastLocationValues Southwest { get; set; }
    }

    public class Geometry 
    {
        public UserLastLocationValues UserLastLocationValues { get; set; }
        public string LocationType { get; set; }
        public Viewport Viewport { get; set; }
    }

    public class Result 
    {
        public List<AddressComponent> AddressComponents { get; set; }
        public string FormattedAddress { get; set; }
        public Geometry Geometry { get; set; }
        public string PlaceId { get; set; }
        public List<string> Types { get; set; }
    }

    public class GeocodeResponse 
    {
        public List<Result> Results { get; set; }
        public string Status { get; set; }
    }

}
