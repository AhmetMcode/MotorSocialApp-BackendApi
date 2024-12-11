using MediatR;
using MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.LocationIcon.Queries.GetAllCustomLocationIcons
{
    public class GetAllCustomLocationIconsQueryHandler : IRequestHandler<GetAllCustomLocationIconsQueryRequest, IList<GetAllCustomLocationIconsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCustomLocationIconsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllCustomLocationIconsQueryResponse>> Handle(GetAllCustomLocationIconsQueryRequest request, CancellationToken cancellationToken)

        {
            var postCategoryFormFiles = await unitOfWork.GetReadRepository<CustomLocationIcon>().GetAllAsync();
            IList<GetAllCustomLocationIconsQueryResponse> responses = new List<GetAllCustomLocationIconsQueryResponse>();
            foreach (var postCategory in postCategoryFormFiles)
            {
                var response = new GetAllCustomLocationIconsQueryResponse
                {
                    Id = postCategory.Id,
                    IconName = postCategory.IconName,
                    IconPath = postCategory.IconPath,
                    UploadedDate = postCategory.CreatedDate,
                    Price= postCategory.Price,

                };

                responses.Add(response);
            }
            return responses;
        }

        
    }
}
