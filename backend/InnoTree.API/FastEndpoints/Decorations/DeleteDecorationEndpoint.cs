using FastEndpoints;
using InnoTree.Application.Usecases.Decorations.Commands.DeleteDecoration;
using MediatR;

namespace InnoTree.API.FastEndpoints.Decorations;

public class DeleteDecorationEndpoint : Ep.NoReq.NoRes
{
    private readonly IMediator _mediator;

    public DeleteDecorationEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete("api/decorations/{id:guid}");
        AllowAnonymous();

        Options(x => x
        .WithName("DeleteDecoration")
        .WithTags("Decorations"));

		Description(d => d
		.ProducesProblemFE(404)
		.Produces(204));
	}

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id", isRequired: true);
        var deleteDecorationCommand = new DeleteDecorationCommand(id);
        await _mediator.Send(deleteDecorationCommand);
    }
}
