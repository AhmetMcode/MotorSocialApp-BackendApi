using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserLastLocationFolder.Command.CreateUserLastLocation
{
    public class CreateUserLastLocationCommandRequest : IRequest
    {
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
