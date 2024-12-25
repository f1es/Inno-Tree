using InnoTree.Core.Models;

namespace InnoTree.Core.Repositories.Interfaces;

public interface IDecorationRepository : IBaseRepository<Decoration>
{
	public Task<Decoration> GetByIdAsync(Guid id, bool trackChanges);
	public Task<IEnumerable<Decoration>> GetAllAsync();
}
