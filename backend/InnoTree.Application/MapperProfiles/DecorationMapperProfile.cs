using AutoMapper;
using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;
using InnoTree.Core.Models;

namespace InnoTree.Application.MapperProfiles;

public class DecorationMapperProfile : Profile
{
    public DecorationMapperProfile()
    {
        CreateMap<DecorationRequestDto, Decoration>();

        CreateMap<Decoration, DecorationResponseDto>();
    }
}
