using MotorSocialApp.Application.Interfaces.FirebaseNotificationServices;
using MotorSocialApp.Persistence.FirebaseNotificationServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MotorSocialApp.Application.Interfaces.GoogleGeocode;
using MotorSocialApp.Application.Interfaces.Repositories;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using MotorSocialApp.Persistence.Context;
using MotorSocialApp.Persistence.GoogleGeocode;
using MotorSocialApp.Persistence.Repositories;
using MotorSocialApp.Persistence.UnitOfWorks;

namespace MotorSocialApp.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient<IGoogleGeocodeService, GoogleGeocodeService>();

            // FirebaseNotificationService için gerekli bağımlılıkları tanımlama
            services.AddTransient<IFirebaseNotificationService>(provider =>
            {
                var serviceAccountPath = configuration["FirebaseConfig:ServiceAccountPath"];
                var projectId = configuration["FirebaseConfig:ProjectId"];
                return new FirebaseNotificationService(serviceAccountPath, projectId);
            });

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
