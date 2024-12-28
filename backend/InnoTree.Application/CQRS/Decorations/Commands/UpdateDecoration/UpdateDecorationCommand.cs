using InnoTree.Core.Dto.Request;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.UpdateDecoration;

public class UpdateDecorationCommand : IRequest
{
	public Guid Id { get; set; }
	public DecorationRequestDto DecorationRequestDto { get; set; }
	public UpdateDecorationCommand(Guid id, DecorationRequestDto decorationRequestDto)
	{
		Id = id;
		DecorationRequestDto = decorationRequestDto;
	}
}
