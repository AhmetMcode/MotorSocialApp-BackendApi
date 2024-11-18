using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

public class UserPhotoConfiguration : IEntityTypeConfiguration<UserPhoto>
{
    public void Configure(EntityTypeBuilder<UserPhoto> builder)
    {
        builder.Property(p => p.PhotoPath)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(p => p.UploadedDate)
               .IsRequired();
    }
}
