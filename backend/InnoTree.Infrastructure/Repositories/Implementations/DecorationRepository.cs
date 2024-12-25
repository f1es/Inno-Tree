using InnoTree.Core.Models;
using InnoTree.Core.Repositories.Interfaces;
using InnoTree.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InnoTree.Infrastructure.Repositories.Implementations;

public class DecorationRepository : BaseRepository<Decoration>, IDecorationRepository
{
    public DecorationRepository(InnoTreeDbContext dbContext)
        : base(dbContext)
    {

    }
    public async Task<IEnumerable<Decoration>> GetAllAsync()
    {
        return await _dbContext.Decorations.ToListAsync();
    }

    public async Task<Decoration> GetByIdAsync(Guid id, bool trackChanges = false)
    {
        if (trackChanges)
        {
            return await _dbContext
                .Decorations
                .FirstOrDefaultAsync(d => d.Id.Equals(id));
        }
        else
        {
            return await _dbContext
                .Decorations
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id.Equals(id));
        }
    }

}
