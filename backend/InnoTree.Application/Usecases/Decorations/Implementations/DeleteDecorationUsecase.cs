using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class DeleteDecorationUsecase : IDeleteDecorationUsecase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteDecorationUsecase(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task DeleteDecorationAsync(Guid id)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(id, trackChanges: false);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {id} not found");
		}

		_unitOfWork.DecorationRepository.Delete(decoration);

		await _unitOfWork.SaveAsync();
	}
}
