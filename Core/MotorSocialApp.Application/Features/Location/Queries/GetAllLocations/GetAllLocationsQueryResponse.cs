using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Location.Queries.GetAllLocations
{
    public class GetAllLocationsQueryResponse
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string IconPath { get; set; }
        public string MarkerId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
