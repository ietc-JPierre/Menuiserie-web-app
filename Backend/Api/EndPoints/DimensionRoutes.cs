using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class DimensionRoutes
{
    public static void MapDimensionRoutes(this WebApplication app)
    {
        app.MapGet("/api/dimensions", async (DimensionUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/dimensions/{id:int}", async (int id, DimensionUseCases useCases) =>
        {
            var dimension = await useCases.GetByIdAsync(id);
            return dimension is null ? Results.NotFound() : Results.Ok(dimension);
        });

        app.MapPost("/api/dimensions", async (Dimension dimension, DimensionUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(dimension);
            return Results.Created($"/api/dimensions/{id}", new { id });
        });

        app.MapPut("/api/dimensions/{id:int}", async (
            int id,
            Dimension dimension,
            DimensionUseCases useCases) =>
        {
            dimension.Id_Dimension = id;
            var updated = await useCases.UpdateAsync(dimension);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/dimensions/{id:int}", async (int id, DimensionUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}