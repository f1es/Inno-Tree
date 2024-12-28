using AutoMapper;
using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Models;
using InnoTree.Core.Repositories.Interfaces;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.CreateDecoration;

public class CreateDecorationCommandHandler : IRequestHandler<CreateDecorationCommand, DecorationResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateDecorationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<DecorationResponseDto> Handle(CreateDecorationCommand request, CancellationToken cancellationToken)
	{
		var decoration = _mapper.Map<Decoration>(request.DecorationRequestDto);
		decoration.Id = Guid.NewGuid();

		_unitOfWork.DecorationRepository.Create(decoration);

		await _unitOfWork.SaveAsync();

		var decorationResponse = _mapper.Map<DecorationResponseDto>(decoration);
		return decorationResponse;
	}
}
