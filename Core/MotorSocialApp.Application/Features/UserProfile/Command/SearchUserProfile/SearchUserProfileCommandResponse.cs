using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserProfile.Command.SearchUserProfile
{
    public class SearchUserProfileCommandResponse
    {
        public Guid Id { get; set; }  // Kullanıcının benzersiz kimliği
        public string FullName { get; set; }
        public string ProfilePhotoPath { get; set; }  // Profil fotoğrafı URL'si veya yolu
      
    }
}
