using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces;
using Infrastructure.Integrations.Google;
using Infrastructure.Parsers.Factories;
using Application.Interfaces;
using Infrastructure.Parsers.Strategies;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOutfitVisionService, GeminiOutfitVisionService>();
        services.AddScoped<IParserFactory, ParserFactory>();
        services.AddScoped<AiParserStrategy>();

        return services;
    }
}