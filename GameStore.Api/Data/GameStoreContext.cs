using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
        new Genre { id = 1, Name = "Action" },
        new Genre { id = 2, Name = "Adventure" },
        new Genre { id = 3, Name = "Role-Playing" },
        new Genre { id = 4, Name = "Strategy" },
        new Genre { id = 5, Name = "Simulation" }
        );
    }
}
