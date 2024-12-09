using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetUserChatGroups
{
    public class GetUserChatGroupsQueryHandler : IRequestHandler<GetUserChatGroupsQueryRequest, IList<GetUserChatGroupsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserChatGroupsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetUserChatGroupsQueryResponse>> Handle(GetUserChatGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            var userChatGroupsConnections = await unitOfWork.GetReadRepository<UserChatGroupConnection>().GetAllAsync(c=>c.UserId==request.UserId);

            IList<ChatGroup> chatGroups = new List<ChatGroup>();
            foreach (var connection in userChatGroupsConnections) {
                var chatGroup = await unitOfWork.GetReadRepository<ChatGroup>().GetAsync(cg=>cg.UniqueId==connection.ChatGroupUniqueId);
                chatGroups.Add(chatGroup);
            }

            var responses = mapper.Map<GetUserChatGroupsQueryResponse, ChatGroup>(chatGroups);
            return responses;   

        }
    }
}
