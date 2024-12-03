using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Post.Queries.GetAllPost
{
    public class GetAllPostQueryResponse
    {
        public Guid UserId { get; set; }
        public string PostContentTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }
        public string PostLocation { get; set; }
        public int PostCategoryId { get; set; }
    }
}
