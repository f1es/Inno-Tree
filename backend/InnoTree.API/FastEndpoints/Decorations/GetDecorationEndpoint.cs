using InnoTree.Core.Dto.Response;
using FastEndpoints;
using MediatR;
using InnoTree.Application.Usecases.Decorations.Queries.GetDecoration;

namespace InnoTree.API.FastEndpoints.Decorations;

public class GetDecorationEndpoint : Ep.NoReq.Res<DecorationResponseDto>
{
    private readonly IMediator _mediator;

    public GetDecorationEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("api/decorations/{id:guid}");
        AllowAnonymous();

		Options(x => x
		.WithName("GetDecoration")
		.WithTags("Decorations"));

		Description(d => d
		.ProducesProblemFE(404)
		.Produces<DecorationResponseDto>());
	}

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id", isRequired: true);
        var getByIdQuery = new GetDecorationQuery(id);
        Response = await _mediator.Send(getByIdQuery);
    }
}
