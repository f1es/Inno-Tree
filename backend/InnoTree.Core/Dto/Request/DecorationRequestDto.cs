namespace InnoTree.Core.Dto.Request;

public record DecorationRequestDto(
	string Author,
	string Message,
	string Type,
	int X,
	int Y);
