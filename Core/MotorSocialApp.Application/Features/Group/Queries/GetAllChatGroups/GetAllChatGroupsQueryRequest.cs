using MediatR;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetAllChatGroups
{
    public class GetAllChatGroupsQueryRequest : IRequest<IList<GetAllChatGroupsQueryResponse>>
    {

    }
}
