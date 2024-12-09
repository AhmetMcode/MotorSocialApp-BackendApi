using MediatR;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.JoinGroup
{
    public class JoinGroupCommandHandler : IRequestHandler<JoinGroupCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public JoinGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(JoinGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var group = await unitOfWork.GetReadRepository<ChatGroup>().GetAsync(g => g.UniqueId == request.GroupId);
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.UserId);

            if (group == null)
            {
                throw new Exception("Böyle bir grup bulunmuyor.");
            }

            if (group.GroupAdminUserId == request.UserId)
            {
                throw new Exception("Grup yöneticisi sizsiniz.");
            }

            var isGroupUserConnection = await unitOfWork.GetReadRepository<UserChatGroupConnection>().AnyAsync(x=>x.ChatGroupUniqueId==request.GroupId && x.UserId==request.UserId);

            if (isGroupUserConnection)
            {
                throw new Exception("Zaten bu gruba üyesiniz");
            }

            var userGroupConnection = new UserChatGroupConnection { 
                UserId = request.UserId,
                ChatGroupUniqueId = request.GroupId,
            };

            group.CurrentMemberCount ++;

            await unitOfWork.GetWriteRepository<UserChatGroupConnection>().AddAsync(userGroupConnection);
            await unitOfWork.GetWriteRepository<ChatGroup>().UpdateAsync(group);
            await unitOfWork.SaveAsync();


        }
    }
}
