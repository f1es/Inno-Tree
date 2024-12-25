using InnoTree.Core.Dto.Response;

namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface IGetDecorationByIdUsecase
{
	public Task<DecorationResponseDto> GetByIdAsync(Guid id);
}
