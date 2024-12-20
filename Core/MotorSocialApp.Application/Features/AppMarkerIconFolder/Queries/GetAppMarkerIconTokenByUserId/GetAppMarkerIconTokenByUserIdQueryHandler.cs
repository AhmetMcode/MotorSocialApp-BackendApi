using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = MotorSocialApp.Domain.Entities.User;
namespace MotorSocialApp.Application.Features.AppMarkerIconFolder.Queries.GetAppMarkerIconTokenByUserId
{
    public class GetAppMarkerIconTokenByUserIdQueryHandler : IRequestHandler<GetAppMarkerIconTokenByUserIdQueryRequest, GetAppMarkerIconTokenByUserIdQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<GetAppMarkerIconTokenByUserIdQueryHandler> logger;

        public GetAppMarkerIconTokenByUserIdQueryHandler(IUnitOfWork unitOfWork,ILogger<GetAppMarkerIconTokenByUserIdQueryHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<GetAppMarkerIconTokenByUserIdQueryResponse> Handle(GetAppMarkerIconTokenByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<UserEntity>().GetAsync(usr=>usr.Id==request.UserId);
            if (user == null) {
                logger.LogError("Kullanıcı Bulunamadı");
                throw new Exception("Kullanıcı Bulunamadı");
            }

            var totalToken = await unitOfWork.GetReadRepository<AppMarkerIconToken>().GetAsync(tkn=>tkn.UserId==user.Id);

            return new GetAppMarkerIconTokenByUserIdQueryResponse
            {
                TotalToken = totalToken.TotalToken
            };
        }
    }
}
