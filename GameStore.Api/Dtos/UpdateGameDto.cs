using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
	[Required]string Name,
	int GenreId,
	[Range(1, 20)]decimal Price,
	DateOnly ReleaseDate);

public record class PatchGameDto(
	string? Name,
	string? Genre,
	decimal? Price,
	DateOnly ReleaseDate);	
