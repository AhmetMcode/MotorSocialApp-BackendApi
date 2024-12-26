using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.DTOs
{
    public class UserChatGroupConnectionUserDto 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? ProfilePhotoPath { get; set; } = "profilePictures/default_profile.jpg";
        public string? Bio { get; set; }
    }

   
}
