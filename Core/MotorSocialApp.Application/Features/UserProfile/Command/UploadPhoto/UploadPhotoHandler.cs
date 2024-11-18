using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto
{
    public class UploadPhotoHandler : IRequestHandler<UploadPhotoRequest, UploadPhotoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UploadPhotoHandler> _logger;
        private readonly IMapper _mapper;

        public UploadPhotoHandler(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment,
            ILogger<UploadPhotoHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UploadPhotoResponse> Handle(UploadPhotoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "userPhotos");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Dosya adı oluşturma (Kullanıcı ID + GUID + orijinal dosya adı)
                var uniqueId = Guid.NewGuid();
                var fileName = $"{request.UserId}_{uniqueId}_{Path.GetFileName(request.Photo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Dosyayı kaydetme
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }

                // Fotoğraf bilgilerini veritabanına kaydetme
                var userPhoto = new UserPhoto
                {
                    UserId = request.UserId,
                    PhotoPath = $"/userPhotos/{fileName}",
                    UploadedDate = DateTime.UtcNow
                };

                await _unitOfWork.GetWriteRepository<UserPhoto>().AddAsync(userPhoto);
                await _unitOfWork.SaveAsync();

                return new UploadPhotoResponse
                {
                    IsSuccess = true,
                    Message = "Fotoğraf başarıyla yüklendi",
                    PhotoUrl = $"/userPhotos/{fileName}" // Tam yolu döndürüyoruz
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fotoğraf yüklenirken hata oluştu.");
                return new UploadPhotoResponse
                {
                    IsSuccess = false,
                    Message = "Fotoğraf yüklenirken hata oluştu"
                };
            }
        }
    }
}
