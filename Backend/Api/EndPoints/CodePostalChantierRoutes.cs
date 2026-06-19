using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class CodePostalChantierRoutes
{
    public static void MapCodePostalChantierRoutes(this WebApplication app)
    {
        app.MapGet("/api/codes-postaux-chantiers", async (CodePostalChantierUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/codes-postaux-chantiers/{codePostal}", async (
            string codePostal,
            CodePostalChantierUseCases useCases) =>
        {
            var result = await useCases.GetByIdAsync(codePostal);
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        app.MapPost("/api/codes-postaux-chantiers", async (
            CodePostalChantier codePostalChantier,
            CodePostalChantierUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(codePostalChantier);
            return Results.Created($"/api/codes-postaux-chantiers/{id}", new { id });
        });

        app.MapPut("/api/codes-postaux-chantiers/{codePostal}", async (
            string codePostal,
            CodePostalChantier codePostalChantier,
            CodePostalChantierUseCases useCases) =>
        {
            codePostalChantier.Code_Postal = codePostal;
            var updated = await useCases.UpdateAsync(codePostalChantier);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/api/codes-postaux-chantiers/{codePostal}", async (
            string codePostal,
            CodePostalChantierUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(codePostal);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}