using Microsoft.Extensions.DependencyInjection;
using MotorSocialApp.Infrastructure.Tokens;
using Microsoft.Extensions.Configuration;

namespace MotorSocialApp.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        }
    }
}
