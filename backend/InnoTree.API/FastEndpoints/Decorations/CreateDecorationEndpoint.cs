using InnoTree.Core.Dto.Request;
using InnoTree.Core.Dto.Response;
using FastEndpoints;
using InnoTree.Application.Usecases.Decorations.Commands.CreateDecoration;
using MediatR;

namespace InnoTree.API.FastEndpoints.Decorations;

public class CreateDecorationEndpoint : Endpoint<DecorationRequestDto, DecorationResponseDto>
{
	private readonly IMediator _mediator;

	public CreateDecorationEndpoint(IMediator mediator)
	{
		_mediator = mediator;
	}

	public override void Configure()
	{
		Post("api/decorations");
		AllowAnonymous();

		Options(x => x
		.WithName("CreateDecoration")
		.WithTags("Decorations"));

		Description(d => d
		.ProducesValidationProblem()
		.Produces<DecorationResponseDto>());
	}

	public override async Task HandleAsync(DecorationRequestDto req, CancellationToken ct)
	{
		var createDecorationCommand = new CreateDecorationCommand(req);
		Response = await _mediator.Send(createDecorationCommand);
		await SendCreatedAtAsync<GetDecorationEndpoint>(Response.Id, Response);
	}
}
