using MediatR;
using Microsoft.AspNetCore.Http;

namespace MotorSocialApp.Application.Features.UserProfile.Command.UploadPhoto
{
    // UploadPhotoRequest sınıfı, MediatR kullanılarak işlenecek bir talep olarak ayarlanır.
    public class UploadPhotoRequest : IRequest<UploadPhotoResponse>
    {
        public Guid UserId { get; set; }
        public IFormFile Photo { get; set; }
    }

    // UploadPhotoResponse sınıfı, işlem sonucunu belirtir.
    public class UploadPhotoResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string PhotoUrl { get; set; }  // Fotoğrafın tam yolu
    }
}
