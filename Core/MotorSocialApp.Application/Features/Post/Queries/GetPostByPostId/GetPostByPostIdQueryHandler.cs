using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostEntity = MotorSocialApp.Domain.Entities.Post;
namespace MotorSocialApp.Application.Features.Post.Queries.GetPostByPostId
{
    public class GetPostByPostIdQueryHandler : IRequestHandler<GetPostByPostIdQueryRequest, GetPostByPostIdQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetPostByPostIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetPostByPostIdQueryResponse> Handle(GetPostByPostIdQueryRequest request, CancellationToken cancellationToken)
        {
            var post = await unitOfWork.GetReadRepository<PostEntity>().GetAsync(post=>post.Id==request.Id);
            post.User = await unitOfWork.GetReadRepository<User>().GetAsync(usr=>usr.Id==post.UserId);
            post.PostCategory = await unitOfWork.GetReadRepository<PostCategoryFormFile>().GetAsync(pc=>pc.Id==post.PostCategoryId);

            var result = new GetPostByPostIdQueryResponse
            {
                Id = post.Id,
                PostCategory = post.PostCategory,
                PostCategoryIconPath = post.PostCategory.PhotoPath,
                PostCategoryId = post.PostCategoryId,
                PostCategoryName = post.PostCategory.CategoryName,
                PostContent = post.PostContent,
                PostContentTitle = post.PostContentTitle,
                PostDate = post.PostDate,
                PostLocation = post.PostLocation,
                User = post.User,
                UserFullName = post.User.FullName,
                UserPhotoPath = post.User.ProfilePhotoPath

            };

          
            return result;
        }
    }
}
