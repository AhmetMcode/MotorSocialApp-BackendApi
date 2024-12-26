using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerRelationshipFolder
{
    public class UserFollowerRelationshipFolderCommandHandler : IRequestHandler<UserFollowerRelationshipFolderCommandRequest, UserFollowerRelationshipFolderCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserFollowerRelationshipFolderCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserFollowerRelationshipFolderCommandResponse> Handle(UserFollowerRelationshipFolderCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await unitOfWork.GetReadRepository<UserFollower>().GetAsync(uf=>uf.FollowedUserId==request.FollowedUserId && uf.FollowerId==request.FollowerId);
            if (response == null)
            {
                return new UserFollowerRelationshipFolderCommandResponse
                {
                    Relationship = false
                };
            }
            else {
                return new UserFollowerRelationshipFolderCommandResponse
                {
                    Relationship = true
                };
            }
        }
    }
}
