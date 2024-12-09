using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Persistence.Configurations
{
    internal class UserChatGroupConnectionConfigurations : IEntityTypeConfiguration<UserChatGroupConnection>
    {
        public void Configure(EntityTypeBuilder<UserChatGroupConnection> builder)
        {
            // ChatGroupUniqueId ile ilişki
            builder.HasOne(uc => uc.ChatGroup)
                   .WithMany(cg => cg.Users)
                   .HasForeignKey(uc => uc.ChatGroupUniqueId) // Ara tablodaki FK
                   .HasPrincipalKey(cg => cg.UniqueId);       // ChatGroup içindeki UniqueId

            // UserId ile User ilişkisi
            builder.HasOne(uc => uc.User)
                   .WithMany(u => u.ChatGroups)
                   .HasForeignKey(uc => uc.UserId)           // Ara tablodaki FK
                   .OnDelete(DeleteBehavior.Cascade);       // Silme davranışı
        }
    }
}
