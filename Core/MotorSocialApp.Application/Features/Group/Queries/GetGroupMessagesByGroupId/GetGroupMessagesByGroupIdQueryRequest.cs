using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetGroupMessagesByGroupId
{
    public class GetGroupMessagesByGroupIdQueryRequest : IRequest<IList<GetGroupMessagesByGroupIdQueryResponse>>
    {
        public Guid GroupId { get; set; }
    }
}
