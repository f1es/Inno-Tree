using InnoTree.Core.Dto.Response;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Queries.GetDecorations;

public class GetDecorationsQuery : IRequest<IEnumerable<DecorationResponseDto>>
{

}
