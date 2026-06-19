using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class TypeClientRoutes
{
    public static void MapTypeClientRoutes(this WebApplication app)
    {
        app.MapGet("/api/types-clients", async (TypeClientUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        app.MapGet("/api/types-clients/{id:int}", async (
            int id,
            TypeClientUseCases useCases) =>
        {
            var typeClient = await useCases.GetByIdAsync(id);

            return typeClient is null
                ? Results.NotFound()
                : Results.Ok(typeClient);
        });
    }
}