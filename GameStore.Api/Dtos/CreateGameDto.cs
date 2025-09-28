using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
[Required]string Name,
[Required]string Genre,
[Range(1, 20)]decimal Price,
DateOnly ReleaseDate
);