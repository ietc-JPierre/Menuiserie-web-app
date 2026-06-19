using Core.IGateways;
using Infrastructure.Gateways;
using Infrastructure.Repositories;
using Infrastructure.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddSingleton(new SqliteConnectionFactory(connectionString!));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientGateway, ClientGateway>();

        services.AddScoped<ITypeClientGateway, TypeClientGateway>();
        services.AddScoped<ICategorieGateway, CategorieGateway>();
        services.AddScoped<IProduitGateway, ProduitGateway>();
        services.AddScoped<IDimensionGateway, DimensionGateway>();
        services.AddScoped<IPersonnelGateway, PersonnelGateway>();
        services.AddScoped<ICodePostalChantierGateway, CodePostalChantierGateway>();
        services.AddScoped<IChantierGateway, ChantierGateway>();
        services.AddScoped<ICommandeGateway, CommandeGateway>();
        services.AddScoped<IClientChantierGateway, ClientChantierGateway>();
        services.AddScoped<IPersonnelCommandeGateway, PersonnelCommandeGateway>();
        services.AddScoped<ICommandeProduitGateway, CommandeProduitGateway>();
        services.AddScoped<IUserGateway, UserGateway>();
        return services;
    }
}