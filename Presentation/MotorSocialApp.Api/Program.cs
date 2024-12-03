using Serilog;
using MotorSocialApp.Persistence;
using MotorSocialApp.Application;
using MotorSocialApp.Infrastructure;
using MotorSocialApp.Application.Exceptions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SignalR;
using MotorSocialApp.Api.Hubs; // SignalR için gerekli

var builder = WebApplication.CreateBuilder(args);

// Serilog yapýlandýrmasýný ekleyin
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Serilog'u ASP.NET Core'a ekleyin
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment;

builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// SignalR Servisini Ekleyin
builder.Services.AddSignalR();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotorSocialApp", Version = "v1", Description = "MotorSocialApp API swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yazip bosluk biraktiktan sonra Token'i girebilirsiniz \r\n\r\n Örnegin: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Authentication önce
app.UseAuthorization(); // Authorization sonra

// SignalR için Hub Endpoint'i Ekleyin
app.MapHub<ExploreHubService>("/exploreHub");

app.MapControllers();

app.Run();
