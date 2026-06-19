using Core.Models;
using Core.UseCases.Abstractions;

namespace Api.EndPoints;

public static class ClientRoutes
{
    public static void MapClientRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/api/clients")
                       .RequireAuthorization();

        group.MapGet("/", async (ClientUseCases useCases) =>
            Results.Ok(await useCases.GetAllAsync())
        );

        group.MapGet("/{id:int}", async (int id, ClientUseCases useCases) =>
        {
            var client = await useCases.GetByIdAsync(id);
            return client is null ? Results.NotFound() : Results.Ok(client);
        });

        group.MapPost("/", async (Client client, ClientUseCases useCases) =>
        {
            var id = await useCases.CreateAsync(client);
            return Results.Created($"/api/clients/{id}", new { id });
        });

        group.MapPut("/{id:int}", async (
            int id,
            Client client,
            ClientUseCases useCases) =>
        {
            client.Id_Client = id;

            var updated = await useCases.UpdateAsync(client);

            return updated ? Results.NoContent() : Results.NotFound();
        });

        group.MapDelete("/{id:int}", async (int id, ClientUseCases useCases) =>
        {
            var deleted = await useCases.DeleteAsync(id);

            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}