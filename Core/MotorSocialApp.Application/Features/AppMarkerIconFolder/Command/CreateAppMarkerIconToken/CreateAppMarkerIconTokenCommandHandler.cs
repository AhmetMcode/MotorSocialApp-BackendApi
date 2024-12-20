using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.AppMarkerIconFolder.Command.CreateAppMarkerIconToken
{
    public class CreateAppMarkerIconTokenCommandHandler : IRequestHandler<CreateAppMarkerIconTokenCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CreateAppMarkerIconTokenCommandHandler> logger;

        public CreateAppMarkerIconTokenCommandHandler(IUnitOfWork unitOfWork,ILogger<CreateAppMarkerIconTokenCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task Handle(CreateAppMarkerIconTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var appMarkerIconToken = new AppMarkerIconToken { 
             CreatedDate = DateTime.Now,
             TotalToken = request.TotalToken,
             UserId = request.UserId,
            };

            await unitOfWork.GetWriteRepository<AppMarkerIconToken>().AddAsync(appMarkerIconToken);
            await unitOfWork.SaveAsync();
        }
    }
}
