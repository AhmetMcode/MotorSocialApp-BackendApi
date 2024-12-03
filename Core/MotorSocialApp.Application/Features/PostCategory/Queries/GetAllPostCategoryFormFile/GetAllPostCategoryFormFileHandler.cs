using AutoMapper;
using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.PostCategory.Queries.GetAllPostCategoryFormFile
{
    public class GetAllPostCategoryFormFileHandler : IRequestHandler<GetAllPostCategoryFormFileRequest, IList<GetAllPostCategoryFormFileResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPostCategoryFormFileHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllPostCategoryFormFileResponse>> Handle(GetAllPostCategoryFormFileRequest request, CancellationToken cancellationToken)
        {
            var postCategoryFormFiles = await unitOfWork.GetReadRepository<PostCategoryFormFile>().GetAllAsync();
            IList<GetAllPostCategoryFormFileResponse> responses  = new List<GetAllPostCategoryFormFileResponse>();
            foreach (var postCategory in postCategoryFormFiles) {
                var response = new GetAllPostCategoryFormFileResponse
                {
                    Id = postCategory.Id,
                    CategoryName = postCategory.CategoryName,
                    PhotoPath = postCategory.PhotoPath,
                    UploadedDate = postCategory.CreatedDate,

                };

                responses.Add(response);
            }
            return responses;
        }
    }
}
