using MediatR;
using AutoMapper;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using MotorSocialApp.Application.Features.UserProfile.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommandRequest, UpdateProfileCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UpdateProfileCommandHandler> _logger;

        public UpdateProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment, ILogger<UpdateProfileCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<UpdateProfileCommandResponse> Handle(UpdateProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<User>().GetAsync(u => u.Id == request.UserId);
            if (user == null)
            {
                throw new UserProfileNotFoundException(request.UserId);
            }

            // Profil resmi yükleme işlemi
            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                try
                {
                    // Dosya yolunu oluştur
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "profilePictures");

                    // Klasör yoksa oluşturun
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Dosya adı (örneğin kullanıcı ID'si ile)
                    var fileName = $"{user.Id}_{Path.GetFileName(request.ProfilePicture.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Dosyayı kaydedin
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ProfilePicture.CopyToAsync(stream);
                    }

                    // Kullanıcının profil resim yolunu güncelle
                    user.ProfilePhotoPath = $"/profilePictures/{fileName}";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Profil resmi yüklenirken hata oluştu.");
                    throw new Exception("Profil resmi yüklenirken hata oluştu.");
                }
            }

            // Kullanıcı profil bilgilerini güncelle
            user.FullName = request.FullName;
            user.Bio = request.Bio;

            await _unitOfWork.GetWriteRepository<User>().UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return new UpdateProfileCommandResponse { IsSuccess = true, Message = "Profile updated successfully" };
        }
    }
}
