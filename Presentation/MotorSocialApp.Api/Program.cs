using Serilog;
using MotorSocialApp.Persistence;
using MotorSocialApp.Application;
using MotorSocialApp.Infrastructure;
using MotorSocialApp.Application.Exceptions;
using Microsoft.OpenApi.Models;
using MotorSocialApp.Api.Hubs; // SignalR için gerekli

var builder = WebApplication.CreateBuilder(args);

// Serilog yapýlandýrmasýný ekleyin
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Serilog'u ASP.NET Core'a ekleyin
builder.Host.UseSerilog();




builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var env = builder.Environment;

builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});
// SignalR Servisini Ekleyin
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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



var app = builder.Build();
// CORS Middleware'i burada
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global hata yönetimi middleware'i en üstte
app.ConfigureExceptionHandlingMiddleware();

app.UseStaticFiles(); // Statik dosyalar

app.UseRouting(); // Routing middleware



// Kimlik doðrulama ve yetkilendirme
app.UseAuthentication();
app.UseAuthorization();

// SignalR Hub Endpoint'leri
app.MapHub<ExploreHubService>("/exploreHub");
app.MapHub<ChatHub>("/chatHub");

// API Controller'larý
app.MapControllers();

app.Run();

