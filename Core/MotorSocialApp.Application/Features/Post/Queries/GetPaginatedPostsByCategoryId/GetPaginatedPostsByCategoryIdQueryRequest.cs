using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPostsByCategoryId
{
    public class GetPaginatedPostsByCategoryIdQueryRequest : IRequest<GetPaginatedPostsByCategoryIdQueryResponse>
    {
        public int Page { get; set; } = 1; // Varsayılan olarak 1. sayfa
        public int CategoryId { get; set; }
    }
}
