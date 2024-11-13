namespace GameStore2.Api.Dtos;

public record class GameDetailsDto(
  Guid Id,
  string Name,
  Guid GenreId,
  decimal Price,
  DateOnly ReleaseDate);

