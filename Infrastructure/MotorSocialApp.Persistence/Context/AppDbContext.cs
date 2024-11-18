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
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tüm entity configurasyonlarını uygula
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Global Soft Delete Filter (IsDeleted özelliği için)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
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
