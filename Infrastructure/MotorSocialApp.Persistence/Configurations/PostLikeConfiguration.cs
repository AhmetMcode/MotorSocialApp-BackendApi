using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Persistence.Configurations
{

    public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            // Post ile ilişki
            builder.HasOne(l => l.Post)
                   .WithMany(p => p.Likes)
                   .HasForeignKey(l => l.PostId)
                   .OnDelete(DeleteBehavior.Cascade); // Post silinirse beğeniler de silinir

            // Kullanıcı ile ilişki
            builder.HasOne(l => l.User)
                   .WithMany(u => u.Likes) // Kullanıcının beğenileri
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silinirse beğeniler kalır

            // Beğeni durumu için zorunlu alan
            builder.Property(l => l.IsLike)
                   .IsRequired();
        }
    }

}
