using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPostsByCategoryId
{
    public class GetPaginatedPostsByCategoryIdQueryResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public List<PostDto> Items { get; set; } = new List<PostDto>();

        public class PostDto
        {
            public Guid UserId { get; set; }
            public string UserPhotoPath { get; set; }
            public string UserFullName { get; set; }
            public string PostContentTitle { get; set; }
            public string PostContent { get; set; }
            public DateTime PostDate { get; set; }
            public string PostLocation { get; set; }
            public int PostCategoryId { get; set; }
            public string PostCategoryIconPath { get; set; }
            public string PostCategoryName { get; set; }
        }
    }
}
