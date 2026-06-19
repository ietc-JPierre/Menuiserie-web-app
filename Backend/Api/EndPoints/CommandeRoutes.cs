using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class CommandeRoutes
{
    public static void MapCommandeRoutes(this WebApplication app)
    {
        app.MapGet("/api/commandes", async (CommandeUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/commandes/{id:int}", async (int id, CommandeUseCases useCases) =>
        {
            var commande = await useCases.GetByIdAsync(id);
            return commande is null ? Results.NotFound() : Results.Ok(commande);
        });

        app.MapPost("/api/commandes", async (Commande commande, CommandeUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(commande);
            return Results.Created($"/api/commandes/{id}", new { id });
        });

        app.MapPut("/api/commandes/{id:int}", async (
            int id,
            Commande commande,
            CommandeUseCases useCases) =>
        {
            commande.Id_Commande = id;
            var updated = await useCases.UpdateAsync(commande);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/commandes/{id:int}", async (int id, CommandeUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}