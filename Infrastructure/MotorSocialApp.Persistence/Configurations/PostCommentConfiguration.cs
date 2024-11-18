using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Persistence.Configurations
{


    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            // Yorum içeriği yapılandırması
            builder.Property(c => c.Content)
                   .IsRequired()
                   .HasMaxLength(500); // Maksimum uzunluk

            // Post ile ilişki
            builder.HasOne(c => c.Post)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade); // Post silinirse yorumlar da silinir

            // Kullanıcı ile ilişki
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Comments) // Kullanıcının yorumları
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silinirse yorumlar kalır
        }
    }

}
