using InnoTree.Core.Dto.Response;

namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface IGetAllDecorationsUsecase
{
	public Task<IEnumerable<DecorationResponseDto>> GetAllDecorationsAsync();
}
