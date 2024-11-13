namespace GameStore2.Api.Dtos;

public record class GameSummaryDto(
  Guid Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate);

