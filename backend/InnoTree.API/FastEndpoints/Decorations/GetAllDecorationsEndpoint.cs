using FastEndpoints;
using InnoTree.Application.Usecases.Decorations.Queries.GetDecorations;
using InnoTree.Core.Dto.Response;
using MediatR;

namespace InnoTree.API.FastEndpoints.Decorations;

public class GetAllDecorationsEndpoint : Ep.NoReq.Res<IEnumerable<DecorationResponseDto>>
{
    private readonly IMediator _mediator;

    public GetAllDecorationsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("api/decorations");
        AllowAnonymous();

		Options(x => x
		.WithName("GetAllDecoration")
		.WithTags("Decorations"));

		Description(d => d
		.Produces<IEnumerable<DecorationResponseDto>>());
	}

    public override async Task HandleAsync(CancellationToken ct)
    {
        var getAllQuery = new GetDecorationsQuery();
        Response = await _mediator.Send(getAllQuery);
    }
}
