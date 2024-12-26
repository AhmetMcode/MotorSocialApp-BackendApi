using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetChatGroupByGroupId
{
    public class GetChatGroupByGroupIdQueryRequest : IRequest<GetChatGroupByGroupIdQueryResponse>
    {
        public Guid UniqueId { get; set; } // Grup adı

    }

}
