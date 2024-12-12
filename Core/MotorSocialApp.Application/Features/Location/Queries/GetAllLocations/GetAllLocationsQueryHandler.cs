using MediatR;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationEntity = MotorSocialApp.Domain.Entities.Location;

namespace MotorSocialApp.Application.Features.Location.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQueryRequest, IList<GetAllLocationsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllLocationsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllLocationsQueryResponse>> Handle(GetAllLocationsQueryRequest request, CancellationToken cancellationToken)
        {
            var locationList= await unitOfWork.GetReadRepository<LocationEntity>().GetAllAsync();
            var response = mapper.Map<GetAllLocationsQueryResponse,LocationEntity>(locationList);
            return response; 
        }
    }
}
