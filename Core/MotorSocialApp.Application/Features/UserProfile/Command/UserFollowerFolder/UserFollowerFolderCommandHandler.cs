using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UserFollowerFolder
{
    public class UserFollowerFolderCommandHandler : IRequestHandler<UserFollowerFolderCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserFollowerFolderCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Handle(UserFollowerFolderCommandRequest request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<UserFollower, UserFollowerFolderCommandRequest>(request);
            await unitOfWork.GetWriteRepository<UserFollower>().AddAsync(model);
            await unitOfWork.SaveAsync();
        }
    }
}
