using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using MotorSocialApp.Application.Features.UserProfile.Exceptions;
using MotorSocialApp.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MotorSocialApp.Application.Features.UserProfile.Command.GetProfile
{
    public class GetUserProfileCommandHandler : IRequestHandler<GetUserProfileCommandRequest, UserProfileDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcı bilgilerini veritabanından ilişkileriyle birlikte alın
            var user = await _unitOfWork.GetReadRepository<User>()
                                        .Find(u => u.Id == request.UserId, enableTracking: false)
                                        .Include(u => u.Followers)
                                        .Include(u => u.FollowedUsers)
                                        .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new UserProfileNotFoundException(request.UserId);
            }

            // Kullanıcı bilgilerini DTO'ya (UserProfileDto) mapleyin
            var userProfileDto = _mapper.Map<UserProfileDto>(user);

            // Takipçi ve takip edilen kullanıcı sayısını DTO'ya ekleyin
            userProfileDto.FollowerCount = user.Followers.Count;
            userProfileDto.FollowingCount = user.FollowedUsers.Count;

            return userProfileDto;
        }
    }
}
