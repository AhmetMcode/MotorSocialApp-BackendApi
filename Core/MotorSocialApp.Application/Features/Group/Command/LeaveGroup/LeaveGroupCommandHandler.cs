using MediatR;
using MotorSocialApp.Application.Features.Group.Command.JoinGroup;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.LeaveGroup
{
    public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public LeaveGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

      

        public async Task Handle(LeaveGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var group = await unitOfWork.GetReadRepository<ChatGroup>().GetAsync(g => g.UniqueId == request.GroupId);
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.UserId);

            if (group == null)
            {
                throw new Exception("Böyle bir grup bulunmuyor.");
            }

           

            var userGroupConnection = await unitOfWork.GetReadRepository<UserChatGroupConnection>().GetAsync(x => x.ChatGroupUniqueId == request.GroupId && x.UserId == request.UserId);

            if (userGroupConnection != null)
            {
                group.Users.Remove(userGroupConnection);
                await unitOfWork.GetWriteRepository<UserChatGroupConnection>().HardDeleteAsync(userGroupConnection);
                if (group.GroupAdminUserId == request.UserId)
                {
                    await unitOfWork.GetWriteRepository<ChatGroup>().HardDeleteAsync(group);
                }
                else {
                    await unitOfWork.GetWriteRepository<ChatGroup>().UpdateAsync(group);
                }
                await unitOfWork.SaveAsync();
            }

            

            

           
        }
    }
}
