using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Dto.Request;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class UpdateDecorationUsecase : IUpdateDecorationUsecase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateDecorationUsecase(
		IUnitOfWork unitOfWork, 
		IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task UpdateDecorationAsync(Guid id, DecorationRequestDto decorationRequestDto)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(id, trackChanges: true);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {id} not found");
		}

		decoration = _mapper.Map(decorationRequestDto, decoration);

		await _unitOfWork.SaveAsync();
	}
}
