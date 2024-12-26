using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace InnoTree.API.Controllers;

[ApiController]
[Route("api/decorations")]
public class DecorationsController : ControllerBase
{
	private readonly IDecorationUsecaseManager _decorationUsecaseManager;

    public DecorationsController(IDecorationUsecaseManager decorationUsecaseManager)
    {
        _decorationUsecaseManager = decorationUsecaseManager;
    }

    [HttpGet]
	public async Task<IActionResult> GetAll()
	{
        var response = await _decorationUsecaseManager.GetAllDecorationsUsecase.GetAllDecorationsAsync();

        return Ok(response);
	}

    [HttpGet("{id:guid}", Name = "DecorationById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _decorationUsecaseManager.GetDecorationByIdUsecase.GetByIdAsync(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(DecorationRequestDto decorationRequestDto)
    {
        var respone = await _decorationUsecaseManager.CreateDecorationUsecase.CreateDecorationAsync(decorationRequestDto);

        return CreatedAtRoute("DecorationById", new { id = respone.DecorationId }, respone);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _decorationUsecaseManager.DeleteDecorationUsecase.DeleteDecorationAsync(id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, DecorationRequestDto decorationRequestDto)
    {
        await _decorationUsecaseManager.UpdateDecorationUsecase.UpdateDecorationAsync(id, decorationRequestDto);

        return NoContent();
    }
}
