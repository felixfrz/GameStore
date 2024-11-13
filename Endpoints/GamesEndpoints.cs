using System;
using GameStore2.Api.Dtos;
using GameStore2.Api.Data;
using GameStore2.Api.Entities;
using GameStore2.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore2.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    // private static readonly List<GameSummaryDto> games =
    // [
    //     new(new Guid("C46131CC-8FCE-4612-8FDF-49735F826EAF"), "Street figther II", "Fighting", 19.99M,
    //         new DateOnly(1992, 7, 15)),
    //     new(new Guid("626DD820-3DDB-4EE7-922C-DD1D0A2F1DB0"), "Final Fantasy XIV", "Roleplaying", 59.99M,
    //         new DateOnly(2010, 9, 30)),
    //     new(new Guid("E3933BD7-AEE8-4987-9A76-4BA13AFFEB47"), "FIFA 23", "Sports", 69.99M, new DateOnly(2022, 9, 27)),
    // ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games
        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games
            .Include(game => game.Genre)
            .Select(game => game.ToGameSummaryDto())
            .AsNoTracking()
            .ToListAsync());

        // GET /games/E3933BD7-AEE8-4987-9A76-4BA13AFFEB47
        group.MapGet("/{Id}", async (Guid Id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(Id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        }).WithName(GetGameEndpointName);

        //POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();


            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();


            return Results.CreatedAtRoute(GetGameEndpointName, new { Id = game.Id }, game.ToGameDetailsDto());
        });


        //PUT /games/
        group.MapPut("/{Id}", async (Guid Id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(Id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                        .CurrentValues
                        .SetValues(updatedGame.ToEntity(Id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /games/xxxxxxxxx
        group.MapDelete("/{Id}", async (Guid Id, GameStoreContext dbContext) =>
        {
            await dbContext.Games
                     .Where(game => game.Id == Id)
                     .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}