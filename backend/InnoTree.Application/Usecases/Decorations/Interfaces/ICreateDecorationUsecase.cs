using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;

namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface ICreateDecorationUsecase
{
	public Task<DecorationResponseDto> CreateDecorationAsync(DecorationRequestDto decorationRequestDto);
}
