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
    public static WebApplication MapGameEndpoints(this WebApplication app)
    {
        //GET
        app.MapGet("games", () => games);

        //GET BY ID
        app.MapGet("games/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        })
            .WithName(GameEndpointName);

        //POST
        app.MapPost("games", (CreateGameDto newGame) =>
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
        app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
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

        //DELETE
        app.MapDelete("games/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
        });
return app;
    }
}
