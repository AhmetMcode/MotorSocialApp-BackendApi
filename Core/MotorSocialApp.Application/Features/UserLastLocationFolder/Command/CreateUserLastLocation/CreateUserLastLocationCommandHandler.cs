using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserLastLocationFolder.Command.CreateUserLastLocation
{
    public class CreateUserLastLocationCommandHandler : IRequestHandler<CreateUserLastLocationCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateUserLastLocationCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Handle(CreateUserLastLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var userLastLocation = mapper.Map<UserLastLocation2, CreateUserLastLocationCommandRequest>(request);
            await unitOfWork.GetWriteRepository<UserLastLocation2>().AddAsync(userLastLocation);
            await unitOfWork.SaveAsync();
            
        }
    }
}
