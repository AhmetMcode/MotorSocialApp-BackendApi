using AutoMapper;
using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostEntity = MotorSocialApp.Domain.Entities.Post;

namespace MotorSocialApp.Application.Features.Post.Queries.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, IList<GetAllPostQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPostQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllPostQueryResponse>> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            var postList = await unitOfWork.GetReadRepository<PostEntity>().GetAllAsync();
            IList<GetAllPostQueryResponse> responses= new List<GetAllPostQueryResponse>();
            foreach (var post in postList) {
                var response = new GetAllPostQueryResponse
                {
                    PostCategoryId = post.PostCategoryId,
                    UserId = post.UserId,
                    PostContent = post.PostContent,
                    PostContentTitle = post.PostContentTitle,
                    PostDate = post.PostDate,
                    PostLocation = post.PostLocation,
           
                };
                responses.Add(response);
            
            }
            return responses; 
        }
    }
}
