using InnoTree.Core.Repositories.Interfaces;
using InnoTree.Infrastructure.Context;

namespace InnoTree.Infrastructure.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly InnoTreeDbContext _dbContext;
    private readonly Lazy<IDecorationRepository> _decorationRepository;

    public IDecorationRepository DecorationRepository => _decorationRepository.Value;

    public UnitOfWork(InnoTreeDbContext dbContext)
    {
        _dbContext = dbContext;

        _decorationRepository = new Lazy<IDecorationRepository>(() => new DecorationRepository(dbContext));
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
