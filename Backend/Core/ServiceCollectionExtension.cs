using Core.UseCases.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ClientUseCases>();
        services.AddScoped<TypeClientUseCases>();
        services.AddScoped<CategorieUseCases>();
        services.AddScoped<ProduitUseCases>();
        services.AddScoped<DimensionUseCases>();
        services.AddScoped<PersonnelUseCases>();
        services.AddScoped<CodePostalChantierUseCases>();
        services.AddScoped<ChantierUseCases>();
        services.AddScoped<CommandeUseCases>();
        services.AddScoped<ClientChantierUseCases>();
        services.AddScoped<PersonnelCommandeUseCases>();
        services.AddScoped<CommandeProduitUseCases>();
        services.AddScoped<UserUseCases>();
        return services;
    }
}