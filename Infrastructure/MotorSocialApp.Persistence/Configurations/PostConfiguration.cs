using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Persistence.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // PostContentTitle özelliği yapılandırması
            builder.Property(p => p.PostContentTitle)
                   .IsRequired()
                   .HasMaxLength(250); // Maksimum uzunluk

            // PostContent özelliği yapılandırması
            builder.Property(p => p.PostContent)
                   .IsRequired()
                   .HasMaxLength(1000); // Maksimum uzunluk

            // PostLocation özelliği yapılandırması
            builder.Property(p => p.PostLocation)
                   .HasMaxLength(100); // Maksimum uzunluk

            // Kullanıcı ile ilişki
            builder.HasOne(p => p.User)
                   .WithMany(u => u.Posts)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinirse Post'lar da silinir

            // Kategori ile ilişki
            builder.HasOne(p => p.PostCategory)
                   .WithMany(c => c.Posts)
                   .HasForeignKey(p => p.PostCategoryId)
                   .OnDelete(DeleteBehavior.Restrict); // Kategori silinirse Post'lar etkilenmez

            // Yorumlar ile ilişki
            builder.HasMany(p => p.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade); // Post silinirse Yorumlar da silinir

            // Beğeniler ile ilişki
            builder.HasMany(p => p.Likes)
                   .WithOne(l => l.Post)
                   .HasForeignKey(l => l.PostId)
                   .OnDelete(DeleteBehavior.Cascade); // Post silinirse Beğeniler de silinir
        }
    }
}
