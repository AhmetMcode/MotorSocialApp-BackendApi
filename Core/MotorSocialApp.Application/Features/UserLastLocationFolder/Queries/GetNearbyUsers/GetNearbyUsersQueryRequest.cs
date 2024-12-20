using MediatR;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserLastLocationFolder.Queries.GetNearbyUsers
{
    public class GetNearbyUsersQueryRequest : IRequest<GetNearbyUsersQueryResponse>
    {
        public Guid UserId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
