using MotorSocialApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using MotorSocialApp.Domain.Common;
using System.Linq.Expressions;

namespace MotorSocialApp.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        // DbSet Tanımları
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<UserChatGroupConnection> UserChatGroupConnections { get; set; }
        public DbSet<GroupChatMessage> GroupChatMessages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserLastLocation2> UserLastLocation2s { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CustomLocationIcon> CustomLocationIcons { get; set; }
        public DbSet<PostCategoryFormFile> PostCategories { get; set; }
        public DbSet<CallForHelp> CallForHelps { get; set; }
        public DbSet<AppMarkerIconToken> AppMarkerIconTokens { get; set; }


        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tüm entity konfigurasyonlarını uygula
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Global Soft Delete Filter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // IEntityBase'i uygulayan entity'lere filtre uygula
                if (typeof(IEntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Call(
                        typeof(EF),
                        nameof(EF.Property),
                        new[] { typeof(bool) },
                        parameter,
                        Expression.Constant("IsDeleted")
                    );
                    var filter = Expression.Lambda(
                        Expression.Equal(property, Expression.Constant(false)),
                        parameter
                    );
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }

    }
}
