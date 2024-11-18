using System;

namespace MotorSocialApp.Application.DTOs
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }  // Kullanıcının benzersiz kimliği
        public string FullName { get; set; }
        public string ProfilePhotoPath { get; set; }  // Profil fotoğrafı URL'si veya yolu
        public string Bio { get; set; }  // Kullanıcı biyografisi
        public int Rating { get; set; }  // Kullanıcının yıldız puanı
        public int FollowerCount { get; set; }  // Kullanıcının takipçi sayısı
        public int FollowingCount { get; set; }  // Kullanıcının takip ettiği kişi sayısı
    }
}
