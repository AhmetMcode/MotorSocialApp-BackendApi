using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPosts.GetPaginatedPostsQueryResponse;
using PostEntity = MotorSocialApp.Domain.Entities.Post;
namespace MotorSocialApp.Application.Features.Post.Queries.GetPaginatedPosts
{
    public class GetPaginatedPostsQueryHandler : IRequestHandler<GetPaginatedPostsQueryRequest, GetPaginatedPostsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetPaginatedPostsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetPaginatedPostsQueryResponse> Handle(GetPaginatedPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var query =await _unitOfWork.GetReadRepository<PostEntity>().GetAllAsync(orderBy:x=>x.OrderByDescending(p=>p.PostDate)); // Veritabanından Post verilerini alıyoruz
            var totalItems = query.Count(); // Toplam kayıt sayısını hesaplıyoruz

          

            // Sayfalama hesaplaması
            var posts = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();


            List<GetPaginatedPostsQueryResponse.PostDto> items = new List<GetPaginatedPostsQueryResponse.PostDto>();
           

            foreach (var post in posts) {
                var user = await _unitOfWork.GetReadRepository<User>().GetAsync(user => user.Id == post.UserId);
                var category = await _unitOfWork.GetReadRepository<PostCategoryFormFile>().GetAsync(pc=>pc.Id==post.PostCategoryId);
                var item = new GetPaginatedPostsQueryResponse.PostDto
                {
                    Id=post.Id,
                    UserId = post.UserId,
                    UserFullName = user.FullName,
                    UserPhotoPath=user.ProfilePhotoPath,
                    PostContentTitle = post.PostContentTitle,
                    PostContent = post.PostContent,
                    PostDate = post.PostDate,
                    PostLocation = post.PostLocation,
                    PostCategoryId = post.PostCategoryId,
                    PostCategoryIconPath = category.PhotoPath,
                    PostCategoryName = category.CategoryName
                };
                items.Add(item);
            }
            var response = new GetPaginatedPostsQueryResponse
            {
                CurrentPage = request.Page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize),
                PageSize = request.PageSize,
                TotalItems = totalItems,
                Items = items
            };

            return response;
        }
    }
}
