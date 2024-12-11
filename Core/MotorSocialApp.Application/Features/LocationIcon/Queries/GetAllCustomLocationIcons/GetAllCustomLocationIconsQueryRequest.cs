using MediatR;
using MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons
{
    public class GetAllCustomLocationIconsQueryRequest : IRequest<IList<GetAllCustomLocationIconsQueryResponse>>
    {
    }
}
