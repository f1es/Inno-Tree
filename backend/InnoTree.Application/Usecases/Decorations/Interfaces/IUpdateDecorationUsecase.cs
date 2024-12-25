using InnoTree.Core.Dto.Request;

namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface IUpdateDecorationUsecase
{
	public Task UpdateDecorationAsync(Guid id, DecorationRequestDto decorationRequestDto);
}
