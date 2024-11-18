using Microsoft.Extensions.DependencyInjection;
using MotorSocialApp.Application.Interfaces.AutoMapper;

namespace MotorSocialApp.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}