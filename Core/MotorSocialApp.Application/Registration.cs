﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MotorSocialApp.Application.Exceptions;
using System.Globalization;
using MediatR;
using MotorSocialApp.Application.Beheviors;
//using MotorSocialApp.Application.Features.Products.Rules;
using MotorSocialApp.Application.Bases;
using MotorSocialApp.Application.Interfaces.AutoMapper;


namespace MotorSocialApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
            services.AddAutoMapper(assembly);

        }

   

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}