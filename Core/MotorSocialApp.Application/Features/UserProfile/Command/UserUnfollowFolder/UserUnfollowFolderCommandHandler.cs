using MediatR;
using MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerFolder;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserUnfollowFolder
{


    public class UserUnfollowFolderCommandHandler : IRequestHandler<UserUnfollowFolderCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserUnfollowFolderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Handle(UserUnfollowFolderCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await unitOfWork.GetReadRepository<UserFollower>().GetAsync(uf => uf.FollowedUserId == request.FollowedUserId && uf.FollowerId == request.FollowerId);

            if (model != null)
            {
                await unitOfWork.GetWriteRepository<UserFollower>().HardDeleteAsync(model);
                await unitOfWork.SaveAsync();
            }

        }


    }
}
