using System;

namespace GameStore2.Api.Entities;

public class Game
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public Guid GenreId { get; set; }
  public Genre? Genre { get; set; }
  public decimal Price { get; set; }
  public DateOnly ReleaseDate { get; set; }
}
