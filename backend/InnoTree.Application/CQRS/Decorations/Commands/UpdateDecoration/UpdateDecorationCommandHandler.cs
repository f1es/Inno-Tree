using AutoMapper;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.UpdateDecoration;

public class UpdateDecorationCommandHandler : IRequestHandler<UpdateDecorationCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateDecorationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task Handle(UpdateDecorationCommand request, CancellationToken cancellationToken)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(request.Id, trackChanges: true);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {request.Id} not found");
		}

		decoration = _mapper.Map(request.DecorationRequestDto, decoration);

		await _unitOfWork.SaveAsync();
	}
}
