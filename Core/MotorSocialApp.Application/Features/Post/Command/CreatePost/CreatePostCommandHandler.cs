using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using AutoMapper;
using PostEntity = MotorSocialApp.Domain.Entities.Post;

namespace MotorSocialApp.Application.Features.Post.Command.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var post = new PostEntity
            {
                UserId = request.UserId,
                PostContentTitle = request.PostContentTitle,
                PostContent = request.PostContent,
                PostDate = request.PostDate,
                PostLocation = request.PostLocation,
                PostCategoryId = request.PostCategoryId
            };

            // Doğru alias kullanımı
            await _unitOfWork.GetWriteRepository<PostEntity>().AddAsync(post);
            await _unitOfWork.SaveAsync();
        }
    }
}
