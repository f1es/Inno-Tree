namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface IDeleteDecorationUsecase
{
	public Task DeleteDecorationAsync(Guid id);
}
