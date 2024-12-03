using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

namespace MotorSocialApp.Persistence.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategoryFormFile>
    {
        public void Configure(EntityTypeBuilder<PostCategoryFormFile> builder)
        {
            // Tablonun yapılandırması
            builder.Property(pc => pc.CategoryName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(pc => pc.PhotoPath)
                   .IsRequired()
                   .HasMaxLength(250);

            // İlişki yapılandırması
            builder.HasMany(pc => pc.Posts)
                   .WithOne(p => p.PostCategory)
                   .HasForeignKey(p => p.PostCategoryId)
                   .OnDelete(DeleteBehavior.Cascade); // Cascade ayarı

            
        }
    }
}
