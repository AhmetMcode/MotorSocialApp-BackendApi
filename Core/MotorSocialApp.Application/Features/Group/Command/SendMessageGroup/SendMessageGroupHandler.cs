using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.Group.Command.SendMessageGroup
{
    public class SendMessageGroupHandler : IRequestHandler<SendMessageGroupRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SendMessageGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Handle(SendMessageGroupRequest request, CancellationToken cancellationToken)
        {
            var newMessage = mapper.Map<GroupChatMessage,SendMessageGroupRequest>(request);
            await unitOfWork.GetWriteRepository<GroupChatMessage>().AddAsync(newMessage);
            await unitOfWork.SaveAsync();
        }
    }
}
