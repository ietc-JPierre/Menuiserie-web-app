using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class PersonnelRoutes
{
    public static void MapPersonnelRoutes(this WebApplication app)
    {
        app.MapGet("/api/personnels", async (PersonnelUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/personnels/{id}", async (string id, PersonnelUseCases useCases) =>
        {
            var personnel = await useCases.GetByIdAsync(id);
            return personnel is null ? Results.NotFound() : Results.Ok(personnel);
        });

        app.MapPost("/api/personnels", async (Personnel personnel, PersonnelUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(personnel);
            return Results.Created($"/api/personnels/{id}", new { id });
        });

        app.MapPut("/api/personnels/{id}", async (
            string id,
            Personnel personnel,
            PersonnelUseCases useCases) =>
        {
            personnel.Id_Personnel = id;
            var updated = await useCases.UpdateAsync(personnel);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/personnels/{id}", async (string id, PersonnelUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}