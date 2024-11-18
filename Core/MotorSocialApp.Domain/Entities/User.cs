using Microsoft.AspNetCore.Identity;
using MotorSocialApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace MotorSocialApp.Domain.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase
    {
        // Mevcut özellikler
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public string? Bio { get; set; }
        public int Rating { get; set; }

        // Navigasyon özellikleri
        public ICollection<UserPhoto> Photos { get; set; } = new List<UserPhoto>();
        public ICollection<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public ICollection<UserFollower> FollowedUsers { get; set; } = new List<UserFollower>();
        public ICollection<Post> Posts { get; set; } = new List<Post>(); // Kullanıcının postları
        public ICollection<PostLike> Likes { get; set; } = new List<PostLike>(); // Kullanıcının beğenileri
        public ICollection<PostComment> Comments { get; set; } = new List<PostComment>(); // Kullanıcının yorumları
    }
}
