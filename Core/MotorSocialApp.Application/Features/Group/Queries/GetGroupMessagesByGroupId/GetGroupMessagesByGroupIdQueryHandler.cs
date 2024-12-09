using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Queries.GetGroupMessagesByGroupId
{
    public class GetGroupMessagesByGroupIdQueryHandler : IRequestHandler<GetGroupMessagesByGroupIdQueryRequest, IList<GetGroupMessagesByGroupIdQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetGroupMessagesByGroupIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetGroupMessagesByGroupIdQueryResponse>> Handle(GetGroupMessagesByGroupIdQueryRequest request, CancellationToken cancellationToken)
        {
            var allMessages= await unitOfWork.GetReadRepository<GroupChatMessage>().GetAllAsync(m=>m.GroupId==request.GroupId);
            var response = mapper.Map<GetGroupMessagesByGroupIdQueryResponse, GroupChatMessage>(allMessages);
            return response;
        }
    }
}
