using AutoMapper;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.DeleteDecoration;

public class DeleteDecorationCommandHandler : IRequestHandler<DeleteDecorationCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteDecorationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task Handle(DeleteDecorationCommand request, CancellationToken cancellationToken)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(request.Id, trackChanges: false);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {request.Id} not found");
		}

		_unitOfWork.DecorationRepository.Delete(decoration);

		await _unitOfWork.SaveAsync();
	}
}
