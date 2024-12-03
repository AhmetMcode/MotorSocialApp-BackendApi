using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPosts
{
    public class GetPaginatedPostsQueryRequest : IRequest<GetPaginatedPostsQueryResponse>
    {
        public int Page { get; set; } = 1; // Varsayılan olarak 1. sayfa

    }
}
