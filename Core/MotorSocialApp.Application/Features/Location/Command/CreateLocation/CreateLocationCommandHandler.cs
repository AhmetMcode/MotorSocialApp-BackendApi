using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationEntity = MotorSocialApp.Domain.Entities.Location;
namespace MotorSocialApp.Application.Features.Location.Command.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<CreateLocationCommandHandler> logger;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,ILogger<CreateLocationCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            
            try {
                var userTotalAppMarkerIconToken = await unitOfWork.GetReadRepository<AppMarkerIconToken>().GetAsync(tkn => tkn.UserId == request.UserId);
                if (userTotalAppMarkerIconToken.TotalToken > request.IconPrice)
                {
                    userTotalAppMarkerIconToken.TotalToken -= request.IconPrice;
                    var location = mapper.Map<LocationEntity, CreateLocationCommandRequest>(request);
                    await unitOfWork.GetWriteRepository<LocationEntity>().AddAsync(location);
                    await unitOfWork.GetWriteRepository<AppMarkerIconToken>().UpdateAsync(userTotalAppMarkerIconToken);
                    await unitOfWork.SaveAsync();
                }
            } catch  {

                throw new Exception("Bu markerı eklemek için jeton satın almalısınız.");
            }
            
            
        }
    }
}
