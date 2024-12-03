using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;


namespace MotorSocialApp.Application.Features.PostCategory.Command.CreatePostCategoryFormFile
{
    public class CreatePostCategoryFormFileHandler : IRequestHandler<CreatePostCategoryFormFileRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CreatePostCategoryFormFileHandler> _logger;
        private readonly IMapper _mapper;

        public CreatePostCategoryFormFileHandler(
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
        public async Task Handle(CreatePostCategoryFormFileRequest request, CancellationToken cancellationToken)
        {
            try {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "categoryPathIcons");
                
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

                var postCategoryFormFile = new PostCategoryFormFile
                {
                    CategoryName = request.CategoryName,
                    PhotoPath = $"/categoryPathIcons/{fileName}",
                    UploadedDate = DateTime.Now,
                };

                await _unitOfWork.GetWriteRepository<PostCategoryFormFile>().AddAsync(postCategoryFormFile);
                await _unitOfWork.SaveAsync();
            } catch (Exception ex) {
                _logger.LogError(ex, "Kategori ikonu yüklenirken hata oluştu.");
              
            }
        }
    }
}
