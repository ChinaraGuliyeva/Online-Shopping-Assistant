namespace Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces;
using Infrastructure.Integrations.Google;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOutfitVisionService, GeminiOutfitVisionService>();

        return services;
    }
}