using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(user=>user.Id==request.GroupAdminUserId);
            if (user == null) {
                throw new Exception("Kullanıcı kaydı bulunamıyor!");
            }

            var newChatGroup = new ChatGroup
            {
                UniqueId = Guid.NewGuid(),
                GroupAdminUserId = user.Id,
                GroupIconPath = request.GroupIconPath,
                Name = request.Name,
                GroupDescription = request.GroupDescription,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                MaxMemberCount = request.MaxMemberCount,
            };
            newChatGroup.CurrentMemberCount = 1;
            var userChatGroupConnection = new UserChatGroupConnection { 
                UserId= user.Id,
                ChatGroupUniqueId = newChatGroup.UniqueId,
            };
            await unitOfWork.GetWriteRepository<ChatGroup>().AddAsync(newChatGroup);
            await unitOfWork.GetWriteRepository<UserChatGroupConnection>().AddAsync(userChatGroupConnection);
            await unitOfWork.SaveAsync();


        }
    }
}
