using System.ComponentModel.DataAnnotations;

namespace GameStore2.Api.Dtos;

public record class CreateGameDto(
    [Required] [StringLength(50)] string Name,
    Guid GenreId,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);