using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class ProduitRoutes
{
    public static void MapProduitRoutes(this WebApplication app)
    {
        app.MapGet("/api/produits", async (ProduitUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/produits/{id:int}", async (int id, ProduitUseCases useCases) =>
        {
            var produit = await useCases.GetByIdAsync(id);
            return produit is null ? Results.NotFound() : Results.Ok(produit);
        });

        app.MapPost("/api/produits", async (Produit produit, ProduitUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(produit);
            return Results.Created($"/api/produits/{id}", new { id });
        });

        app.MapPut("/api/produits/{id:int}", async (
            int id,
            Produit produit,
            ProduitUseCases useCases) =>
        {
            produit.Id_Produit = id;
            var updated = await useCases.UpdateAsync(produit);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/produits/{id:int}", async (int id, ProduitUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);

            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}