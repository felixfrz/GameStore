using System;
using GameStore2.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore2.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Genre>().HasData(
            new { Id = new Guid("86E0D229-511F-41B5-90D5-347A628713E4"), Name = "Fighting" },
            new { Id = new Guid("4D3C5B93-6E15-4665-9EC3-9B7993FEFD31"), Name = "Sports" },
            new { Id = new Guid("8B45BC5A-76D6-42C6-A44F-2594C92F7031"), Name = "Racing" });
    }
}