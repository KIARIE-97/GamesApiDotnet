using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
 const string GameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new(
        1,
        "euphoria",
        "drama",
        34.44m,
        new DateOnly(2020, 2, 2)
    ),
     new(
        2,
        "friends",
        "sitcom/comedy",
        34.44m,
        new DateOnly(2020, 2, 2)
    )
    ];
    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();

        //GET
        group.MapGet("/", () => games);

        //GET BY ID
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        })
            .WithName(GameEndpointName);

        //POST
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);
            return Results.CreatedAtRoute(GameEndpointName, new { id = game.Id }, game);
        });

        //put
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
         id,
         updateGame.Name,
         updateGame.Genre,
         updateGame.Price,
         updateGame.ReleaseDate
            );
            return Results.NoContent();
        });

        //patch
        // group.MapPatch("/{id}", (int id, PatchGameDto patchGame) =>
        // {
        //     var game = games.FirstOrDefault(g => g.Id == id);
        //     if (game == null) return Results.NotFound();

        //     var updatedGame = game with
        //     {
        //         Name = patchGame.Name ?? game.Name,
        //         Genre = patchGame.Genre ?? game.Genre,
        //         Price = patchGame.Price ?? game.Price,
        //         ReleaseDate = patchGame.ReleaseDate ?? game.ReleaseDate
        //     };

        //     var index = games.FindIndex(g => g.Id == id);
        //     games[index] = updatedGame;
        //      return Results.Ok(updatedGame);
        // });

        //DELETE
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
        });
return group;
    }
}
