using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Models;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class CreateDecorationUsecase : ICreateDecorationUsecase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateDecorationUsecase(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DecorationResponseDto> CreateDecorationAsync(DecorationRequestDto decorationRequestDto)
	{
        var decoration = _mapper.Map<Decoration>(decorationRequestDto);
        decoration.Id = Guid.NewGuid();

        _unitOfWork.DecorationRepository.Create(decoration);

        await _unitOfWork.SaveAsync();

		var decorationResponse = _mapper.Map<DecorationResponseDto>(decoration);
        return decorationResponse;
	}
}
