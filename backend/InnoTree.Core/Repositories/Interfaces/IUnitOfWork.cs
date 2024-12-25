namespace InnoTree.Core.Repositories.Interfaces;

public interface IUnitOfWork
{
	public IDecorationRepository DecorationRepository { get; }

	public Task SaveAsync();
}
