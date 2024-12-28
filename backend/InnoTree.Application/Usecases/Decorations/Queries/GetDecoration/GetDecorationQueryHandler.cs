using AutoMapper;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Exceptions;
using InnoTree.Core.Repositories.Interfaces;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Queries.GetDecoration;

public class GetDecorationQueryHandler : IRequestHandler<GetDecorationQuery, DecorationResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetDecorationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<DecorationResponseDto> Handle(GetDecorationQuery request, CancellationToken cancellationToken)
	{
		var decoration = await _unitOfWork.DecorationRepository.GetByIdAsync(request.Id, trackChanges: false);

		if (decoration is null)
		{
			throw new NotFoundException($"Decoration with id {request.Id} not found");
		}

		var decorationResponse = _mapper.Map<DecorationResponseDto>(decoration);

		return decorationResponse;
	}
}
