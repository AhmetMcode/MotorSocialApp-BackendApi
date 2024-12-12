using MediatR;
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

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = mapper.Map<LocationEntity, CreateLocationCommandRequest>(request);
            await unitOfWork.GetWriteRepository<LocationEntity>().AddAsync(location);
            await unitOfWork.SaveAsync();
        }
    }
}
