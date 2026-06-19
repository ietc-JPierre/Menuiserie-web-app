using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class ClientChantierRoutes
{
    public static void MapClientChantierRoutes(this WebApplication app)
    {
        app.MapGet("/api/clients-chantiers", async (ClientChantierUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapPost("/api/clients-chantiers", async (
            ClientChantier item,
            ClientChantierUseCases useCases) =>
        {
            await useCases.CreateAsync(item);
            return Results.Created("/api/clients-chantiers", item);
        });

        app.MapDelete("/api/clients-chantiers/{idClient:int}/{idChantier:int}", async (
            int idClient,
            int idChantier,
            ClientChantierUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(idClient, idChantier);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}