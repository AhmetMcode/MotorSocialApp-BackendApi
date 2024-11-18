using MediatR;
using System;
using System.Collections.Generic;

namespace MotorSocialApp.Application.Features.UserProfile.Query.GetUserPhotos
{
    public class GetUserPhotosRequest : IRequest<GetUserPhotosResponse>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserPhotosResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> PhotoPaths { get; set; } = new List<string>(); // Fotoğraf dosya yolları
    }
}
