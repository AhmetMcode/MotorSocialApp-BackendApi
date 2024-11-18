using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FullName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.ProfilePhotoPath)
               .HasMaxLength(250);

        builder.Property(u => u.Bio)
               .HasMaxLength(500);

        // Kullanıcı ve Fotoğraflar arasındaki ilişki
        builder.HasMany(u => u.Photos)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinince fotoğraflar silinsin

        // Kullanıcı ve Postlar arasındaki ilişki
        builder.HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silinince postlar silinsin

    }
}
