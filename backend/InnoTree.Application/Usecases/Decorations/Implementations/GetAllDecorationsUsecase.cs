using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class GetAllDecorationsUsecase : IGetAllDecorationsUsecase
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

    public GetAllDecorationsUsecase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
		_mapper = mapper;
    }
    public async Task<IEnumerable<DecorationResponseDto>> GetAllDecorationsAsync()
	{
		var decorations = await _unitOfWork.DecorationRepository.GetAllAsync();

		var decorationsResponse = _mapper.Map<IEnumerable<DecorationResponseDto>>(decorations);

		return decorationsResponse;
	}
}
