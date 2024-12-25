using InnoTree.Core.Repositories.Interfaces;
using InnoTree.Infrastructure.Context;

namespace InnoTree.Infrastructure.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly InnoTreeDbContext _dbContext;
    public BaseRepository(InnoTreeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}
