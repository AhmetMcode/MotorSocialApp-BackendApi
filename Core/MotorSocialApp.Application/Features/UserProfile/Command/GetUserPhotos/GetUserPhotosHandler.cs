using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Features.UserProfile.Query.GetUserPhotos;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Query.GetUserPhotos
{
    public class GetUserPhotosHandler : IRequestHandler<GetUserPhotosRequest, GetUserPhotosResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserPhotosHandler> _logger;

        public GetUserPhotosHandler(IUnitOfWork unitOfWork, ILogger<GetUserPhotosHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<GetUserPhotosResponse> Handle(GetUserPhotosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Kullanıcıya ait fotoğrafları veritabanından al
                var photos = await _unitOfWork.GetReadRepository<UserPhoto>().GetAllAsync(p => p.UserId == request.UserId);

                // Fotoğraf dosya yollarını topla
                var photoPaths = photos.Select(p => p.PhotoPath).ToList();

                return new GetUserPhotosResponse
                {
                    IsSuccess = true,
                    PhotoPaths = photoPaths,
                    Message = "Fotoğraflar başarıyla getirildi."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fotoğraflar getirilirken hata oluştu.");
                return new GetUserPhotosResponse
                {
                    IsSuccess = false,
                    Message = "Fotoğraflar getirilirken hata oluştu."
                };
            }
        }
    }
}
