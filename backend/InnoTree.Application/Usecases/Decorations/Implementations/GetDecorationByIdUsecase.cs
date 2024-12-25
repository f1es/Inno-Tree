using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class GetDecorationByIdUsecase : IGetDecorationByIdUsecase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetDecorationByIdUsecase(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<DecorationResponseDto> GetByIdAsync(Guid id)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(id, trackChanges: false);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {id} not found");
		}

		var decorationResponse = _mapper.Map<DecorationResponseDto>(decoration);

		return decorationResponse;
	}
}
