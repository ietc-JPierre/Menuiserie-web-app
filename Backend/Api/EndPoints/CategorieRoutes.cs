using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class CategorieRoutes
{
    public static void MapCategorieRoutes(this WebApplication app)
    {
        app.MapGet("/api/categories", async (CategorieUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/categories/{id:int}", async (int id, CategorieUseCases useCases) =>
        {
            var categorie = await useCases.GetByIdAsync(id);
            return categorie is null ? Results.NotFound() : Results.Ok(categorie);
        });

        app.MapPost("/api/categories", async (Categorie categorie, CategorieUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(categorie);
            return Results.Created($"/api/categories/{id}", new { id });
        });

        app.MapPut("/api/categories/{id:int}", async (
            int id,
            Categorie categorie,
            CategorieUseCases useCases) =>
        {
            categorie.Id_Categorie = id;
            var updated = await useCases.UpdateAsync(categorie);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/categories/{id:int}", async (int id, CategorieUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);

            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}