using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.CreateDecoration;

public class CreateDecorationCommand : IRequest<DecorationResponseDto>
{
	public DecorationRequestDto DecorationRequestDto { get; set; }

	public CreateDecorationCommand(DecorationRequestDto decorationRequestDto)
	{
		DecorationRequestDto = decorationRequestDto;
	}
}
