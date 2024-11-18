//using MediatR;
//using MotorSocialApp.Application.Interfaces.UnitOfWorks;
//using MotorSocialApp.Domain.Entities;
//using AutoMapper;

//using PostEntity = MotorSocialApp.Domain.Entities.Post;

//namespace MotorSocialApp.Application.Features.Post.Command.CreatePost
//{
//    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
//        {

            

//            var post = new PostEntity
//            {
//                UserId = request.UserId,
//                PostContentTitle = request.PostContentTitle,
//                PostContent = request.PostContent,
//                PostDate = request.PostDate,
//                PostLocation = request.PostLocation,
//                PostCategoryId = request.PostCategoryId
//            };

//            await _unitOfWork.GetWriteRepository<Post>().AddAsync(post);
//            await _unitOfWork.SaveAsync();

//            return new CreatePostCommandResponse
//            {
//                PostId = post.Id,
//                Message = "Post successfully created."
//            };
//        }
//    }
//}
