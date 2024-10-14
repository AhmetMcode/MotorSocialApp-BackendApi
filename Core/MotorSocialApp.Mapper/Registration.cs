using Microsoft.Extensions.DependencyInjection;


namespace MotorSocialApp.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<MotorSocialApp.Application.Interfaces.AutoMapper.IMapper, MotorSocialApp.Mapper.AutoMapper.Mapper>();
        }
    }
}
