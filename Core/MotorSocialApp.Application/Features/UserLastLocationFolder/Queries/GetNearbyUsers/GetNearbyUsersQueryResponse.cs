using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserLastLocationFolder.Queries.GetNearbyUsers
{
    public class GetNearbyUsersQueryResponse { 
       public int NearbyCountUser { get; set; }
    }
}
