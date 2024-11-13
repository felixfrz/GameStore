using System;
using GameStore2.Api.Dtos;
using GameStore2.Api.Entities;

namespace GameStore2.Api.Mapping;

public static class GenreMapping
{
  public static GenreDto ToDto(this Genre genre)
  {
    return new GenreDto(genre.Id, genre.Name);
  }
}
