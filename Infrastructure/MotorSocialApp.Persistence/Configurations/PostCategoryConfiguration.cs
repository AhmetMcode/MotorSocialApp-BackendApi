using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Persistence.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            // Tablonun yapılandırması
            builder.Property(pc => pc.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(pc => pc.IconPath)
                   .IsRequired()
                   .HasMaxLength(250);

            // İlişki yapılandırması
            builder.HasMany(pc => pc.Posts)
                   .WithOne(p => p.PostCategory)
                   .HasForeignKey(p => p.PostCategoryId)
                   .OnDelete(DeleteBehavior.Cascade); // Cascade ayarı

            // Seed Data
            builder.HasData(
                new PostCategory
                {
                    Id = 1,
                    Name = "Voleybol",
                    IconPath = "assets/svg/volleyball.svg",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new PostCategory
                {
                    Id = 2,
                    Name = "Patiler",
                    IconPath = "assets/svg/paw.svg",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new PostCategory
                {
                    Id = 3,
                    Name = "Duyuru",
                    IconPath = "assets/svg/megaphone.svg",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
