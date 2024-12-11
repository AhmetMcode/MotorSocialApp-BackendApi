using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Features.PostCategory.Command.CreatePostCategoryFormFile;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.LocationIcon.Command.CreateLocationIcon
{
    public class CreateLocationIconCommandHandler : IRequestHandler<CreateLocationIconCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CreatePostCategoryFormFileHandler> _logger;
        private readonly IMapper _mapper;

        public CreateLocationIconCommandHandler(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment,
            ILogger<CreatePostCategoryFormFileHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task Handle(CreateLocationIconCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "customLocationIconsFolder");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                //dosya adı oluşturma

                var fileName = $"{request.CategoryName}.jpg";
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Dosyayı kaydetme
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.CategoryPhoto.CopyToAsync(stream);
                }

                var locationIcon = new CustomLocationIcon
                {
                    IconName = request.CategoryName,
                    IconPath = $"/customLocationIconsFolder/{fileName}",
                    UploadedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    Price= request.Price,

                };

                await _unitOfWork.GetWriteRepository<CustomLocationIcon>().AddAsync(locationIcon);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lokasyon ikonu yüklenirken hata oluştu.");

            }
        }

        
    }
}
