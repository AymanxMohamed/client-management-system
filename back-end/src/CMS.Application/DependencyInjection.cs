using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);
        return services;
    }
}