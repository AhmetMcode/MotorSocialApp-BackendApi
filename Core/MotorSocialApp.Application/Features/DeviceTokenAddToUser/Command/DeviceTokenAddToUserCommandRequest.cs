using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.DeviceTokenAddToUser.Command
{
    public class DeviceTokenAddToUserCommandRequest : IRequest
    {
        public Guid UserId { get; set; }
        public string DeviceToken { get; set; }
    }
}
