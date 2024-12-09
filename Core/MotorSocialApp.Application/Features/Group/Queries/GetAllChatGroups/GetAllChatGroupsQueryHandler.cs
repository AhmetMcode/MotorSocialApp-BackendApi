using MediatR;
using Microsoft.EntityFrameworkCore;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetAllChatGroups
{
    public class GetAllChatGroupsQueryHandler : IRequestHandler<GetAllChatGroupsQueryRequest, IList<GetAllChatGroupsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllChatGroupsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllChatGroupsQueryResponse>> Handle(GetAllChatGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            var chatGroups = await unitOfWork.GetReadRepository<ChatGroup>()
                .GetAllAsync();

            IList<GetAllChatGroupsQueryResponse> responses = new List<GetAllChatGroupsQueryResponse>();
            foreach (var  group in chatGroups)
            {
                var response = new GetAllChatGroupsQueryResponse
                {
                    UniqueId=group.UniqueId,
                    GroupAdminUserId = group.GroupAdminUserId,
                    GroupDescription = group.GroupDescription,
                    GroupIconPath = group.GroupIconPath,
                    Name = group.Name,
                    CurrentMemberCount=group.CurrentMemberCount,
                    MaxMemberCount=group.MaxMemberCount
                    
                };

                responses.Add(response);
            }
            return responses;
        }
    }
}
