using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
[Required] string Name,
int GenreId,
[Range(1, 20)] decimal Price,
DateOnly ReleaseDate
);