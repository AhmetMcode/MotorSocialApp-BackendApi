using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.DeviceTokenAddToUser.Command
{
    public class DeviceTokenAddToUserCommandHandler : IRequestHandler<DeviceTokenAddToUserCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<DeviceTokenAddToUserCommandHandler> logger;

        public DeviceTokenAddToUserCommandHandler(IUnitOfWork unitOfWork,ILogger<DeviceTokenAddToUserCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task Handle(DeviceTokenAddToUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(usr=>usr.Id==request.UserId);
            if (user == null) {
                logger.LogError("Kullanıcı Bulunamadı");
                throw new Exception("Kullanıcı bulunamadı");
            }
            if (user.DeviceToken == request.DeviceToken) {
                return;
            }

            user.DeviceToken = request.DeviceToken;
            await unitOfWork.GetWriteRepository<User>().UpdateAsync(user);
            await unitOfWork.SaveAsync();

        }
    }
}
