using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<IList<GetAllPostQueryResponse>>
    {

    }
}
