using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetUserChatGroups
{
    public class GetUserChatGroupsQueryRequest : IRequest<IList<GetUserChatGroupsQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
