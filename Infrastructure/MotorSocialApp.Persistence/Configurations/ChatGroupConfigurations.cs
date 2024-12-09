using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Persistence.Configurations
{
    public class ChatGroupConfigurations : IEntityTypeConfiguration<ChatGroup>
    {
        public void Configure(EntityTypeBuilder<ChatGroup> builder)
        {

            builder.HasMany(cg => cg.Users)
               .WithOne(uc => uc.ChatGroup)
               .HasForeignKey(uc => uc.ChatGroupUniqueId) // Ara tablodaki FK
               .HasPrincipalKey(cg => cg.UniqueId)       // ChatGroup içindeki UniqueId
               .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
