using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class PersonnelCommandeRoutes
{
    public static void MapPersonnelCommandeRoutes(this WebApplication app)
    {
        app.MapGet("/api/personnels-commandes", async (PersonnelCommandeUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapPost("/api/personnels-commandes", async (
            PersonnelCommande item,
            PersonnelCommandeUseCases useCases) =>
        {
            await useCases.CreateAsync(item);
            return Results.Created("/api/personnels-commandes", item);
        });

        app.MapDelete("/api/personnels-commandes/{idPersonnel}/{idCommande:int}", async (
            string idPersonnel,
            int idCommande,
            PersonnelCommandeUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(idPersonnel, idCommande);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}