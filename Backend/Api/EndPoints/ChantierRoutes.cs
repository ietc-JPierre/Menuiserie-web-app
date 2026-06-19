using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class ChantierRoutes
{
    public static void MapChantierRoutes(this WebApplication app)
    {
        app.MapGet("/api/chantiers", async (ChantierUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/chantiers/{id:int}", async (int id, ChantierUseCases useCases) =>
        {
            var chantier = await useCases.GetByIdAsync(id);
            return chantier is null ? Results.NotFound() : Results.Ok(chantier);
        });

        app.MapPost("/api/chantiers", async (Chantier chantier, ChantierUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(chantier);
            return Results.Created($"/api/chantiers/{id}", new { id });
        });

        app.MapPut("/api/chantiers/{id:int}", async (
            int id,
            Chantier chantier,
            ChantierUseCases useCases) =>
        {
            chantier.Id_Chantier = id;
            var updated = await useCases.UpdateAsync(chantier);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/chantiers/{id:int}", async (int id, ChantierUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}