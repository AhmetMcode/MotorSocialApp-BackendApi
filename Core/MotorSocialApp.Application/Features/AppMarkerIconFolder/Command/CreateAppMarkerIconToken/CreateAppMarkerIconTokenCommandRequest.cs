using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.AppMarkerIconFolder.Command.CreateAppMarkerIconToken
{
    public class CreateAppMarkerIconTokenCommandRequest : IRequest
    {
        public Guid UserId { get; set; }
        public int TotalToken { get; set; }
    }
}
