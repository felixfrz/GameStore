using System;

namespace GameStore2.Api.Entities;

public class Genre
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
}