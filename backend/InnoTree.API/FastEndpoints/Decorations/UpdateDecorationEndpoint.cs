using FastEndpoints;
using InnoTree.Application.Usecases.Decorations.Commands.UpdateDecoration;
using InnoTree.Core.Dto.Request;
using MediatR;

namespace InnoTree.API.FastEndpoints.Decorations;

public class UpdateDecorationEndpoint : Endpoint<DecorationRequestDto>
{
	private readonly IMediator _mediator;

	public UpdateDecorationEndpoint(IMediator mediator)
	{
		_mediator = mediator;
	}

	public override void Configure()
	{
		Put("api/decorations/{id:guid}");
		AllowAnonymous();

		Options(x => x
		.WithName("UpdateDecoration")
		.WithTags("Decorations"));

		Description(d => d
		.ProducesValidationProblem()
		.ProducesProblemFE(404)
		.Produces(204));
	}

	public override async Task HandleAsync(DecorationRequestDto req, CancellationToken ct)
	{
		var id = Route<Guid>("id");

		var updateDecorationCommand = new UpdateDecorationCommand(id, req);
		await _mediator.Send(updateDecorationCommand);
	}
}
