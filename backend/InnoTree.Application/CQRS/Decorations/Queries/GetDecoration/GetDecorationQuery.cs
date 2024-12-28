using InnoTree.Core.Dto.Response;
using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Queries.GetDecoration;

public class GetDecorationQuery : IRequest<DecorationResponseDto>
{
	public Guid Id { get; set; }
	public GetDecorationQuery(Guid id)
	{
		Id = id;
	}
}
