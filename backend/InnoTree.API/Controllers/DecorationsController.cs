using InnoTree.Application.Usecases.Decorations.Commands.CreateDecoration;
using InnoTree.Application.Usecases.Decorations.Commands.DeleteDecoration;
using InnoTree.Application.Usecases.Decorations.Commands.UpdateDecoration;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Application.Usecases.Decorations.Queries.GetDecoration;
using InnoTree.Application.Usecases.Decorations.Queries.GetDecorations;
using InnoTree.Core.Dto.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoTree.API.Controllers;

[ApiController]
[Route("api/decorations")]
public class DecorationsController : ControllerBase
{
    private readonly IMediator _mediator;
	private readonly IDecorationUsecaseManager _decorationUsecaseManager;

    public DecorationsController(IDecorationUsecaseManager decorationUsecaseManager, IMediator mediator)
    {
        _decorationUsecaseManager = decorationUsecaseManager;
        _mediator = mediator;
    }

    [HttpGet]
	public async Task<IActionResult> GetAll()
	{
        var getAllQuery = new GetDecorationsQuery();
        var response = await _mediator.Send(getAllQuery);

        return Ok(response);
	}

    [HttpGet("{id:guid}", Name = "DecorationById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getByIdQuery = new GetDecorationQuery(id);
        var response = await _mediator.Send(getByIdQuery);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DecorationRequestDto decorationRequestDto)
    {
        var createDecorationCommand = new CreateDecorationCommand(decorationRequestDto);
        var response = await _mediator.Send(createDecorationCommand);

        return CreatedAtRoute("DecorationById", new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteDecorationCommand = new DeleteDecorationCommand(id);
        await _mediator.Send(deleteDecorationCommand);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, DecorationRequestDto decorationRequestDto)
    {
        var updateDecorationCommand = new UpdateDecorationCommand(id, decorationRequestDto);
        await _mediator.Send(updateDecorationCommand);

        return NoContent();
    }
}
