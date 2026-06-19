using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class CommandeProduitRoutes
{
    public static void MapCommandeProduitRoutes(this WebApplication app)
    {
        app.MapGet("/api/commandes-produits", async (CommandeProduitUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapPost("/api/commandes-produits", async (
            CommandeProduit item,
            CommandeProduitUseCases useCases) =>
        {
            await useCases.CreateAsync(item);
            return Results.Created("/api/commandes-produits", item);
        });

        app.MapDelete(
            "/api/commandes-produits/{idProduit:int}/{idDimension:int}/{idCommande:int}",
            async (
                int idProduit,
                int idDimension,
                int idCommande,
                CommandeProduitUseCases useCases) =>
            {
                var deleted = await useCases.DeleteAsync(idProduit, idDimension, idCommande);
                return deleted ? Results.NoContent() : Results.NotFound();
            }
        );
    }
}