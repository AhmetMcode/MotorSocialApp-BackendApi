using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.AppMarkerIconFolder.Queries.GetAppMarkerIconTokenByUserId
{
    public class GetAppMarkerIconTokenByUserIdQueryRequest : IRequest<GetAppMarkerIconTokenByUserIdQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}
