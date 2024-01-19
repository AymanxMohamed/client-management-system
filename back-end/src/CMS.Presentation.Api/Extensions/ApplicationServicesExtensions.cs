using CMS.Application;
using CMS.Infrastructure;

namespace CMS.Presentation.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services
            .AddPresentation()
            .AddInfrastructure(configuration)
            .AddApplication()
            .AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        
        return services;
    }
}