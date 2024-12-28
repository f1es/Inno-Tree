using MediatR;

namespace InnoTree.Application.Usecases.Decorations.Commands.DeleteDecoration;

public class DeleteDecorationCommand : IRequest
{
	public Guid Id { get; set; }

	public DeleteDecorationCommand(Guid id)
	{
		Id = id;
	}
}
