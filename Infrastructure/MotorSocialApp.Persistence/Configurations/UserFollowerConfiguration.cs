using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;

public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
{
    public void Configure(EntityTypeBuilder<UserFollower> builder)
    {
        // Composite key (bileşik anahtar) tanımlama
        builder.HasKey(uf => new { uf.FollowerId, uf.FollowedUserId });

        builder.HasOne(uf => uf.Follower)
               .WithMany(u => u.FollowedUsers)
               .HasForeignKey(uf => uf.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(uf => uf.FollowedUser)
               .WithMany(u => u.Followers)
               .HasForeignKey(uf => uf.FollowedUserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
