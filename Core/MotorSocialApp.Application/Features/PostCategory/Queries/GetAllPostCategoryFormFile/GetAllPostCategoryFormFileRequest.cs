using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile
{
    public class GetAllPostCategoryFormFileRequest : IRequest<IList<GetAllPostCategoryFormFileResponse>>
    {
    }
}
