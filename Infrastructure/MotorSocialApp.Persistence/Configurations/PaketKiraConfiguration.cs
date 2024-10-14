//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using MotorSocialApp.Domain.Entities;
//using MotorSocialApp.Domain.Entities.JunctionTables;

//namespace MotorSocialApp.Persistence.Configurations
//{
//    public class PaketKiraConfiguration : IEntityTypeConfiguration<PaketKira>
//    {
//        public void Configure(EntityTypeBuilder<PaketKira> builder)
//        {
//            builder.HasKey(x => new { x.PaketId, x.KiraId });

//            builder.HasOne(p => p.Paket)
//                .WithMany(pc => pc.PaketKiralar)
//                .HasForeignKey(p => p.PaketId).OnDelete(DeleteBehavior.Cascade);


//            builder.HasOne(c => c.Kira)
//                .WithMany(pc => pc.PaketKiralar)
//                .HasForeignKey(c => c.KiraId).OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}
