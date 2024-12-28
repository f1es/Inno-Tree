using AutoMapper;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Repositories.Interfaces;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Queries.GetDecorations;

public class GetDecorationsQueryHandler : IRequestHandler<GetDecorationsQuery, IEnumerable<DecorationResponseDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetDecorationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<IEnumerable<DecorationResponseDto>> Handle(GetDecorationsQuery request, CancellationToken cancellationToken)
	{
		var decorations = await _unitOfWork.DecorationRepository.GetAllAsync();

		var decorationsResponse = _mapper.Map<IEnumerable<DecorationResponseDto>>(decorations);

		return decorationsResponse;
	}
}
