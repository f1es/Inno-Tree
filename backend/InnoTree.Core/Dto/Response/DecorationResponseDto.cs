namespace InnoTree.Core.Dto.Response;

public record DecorationResponseDto(
	Guid Id,
	string Author,
	string Message,
	string Type,
	int X,
	int Y);
