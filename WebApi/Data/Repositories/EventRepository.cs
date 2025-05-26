using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Data.Contexts;
using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Data.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{

    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        var entities = await _context.Events
            .Include(ep => ep.Packages)
            .ThenInclude(p => p.Package)
            .ToListAsync();

        return new RepositoryResult<IEnumerable<EventEntity>> { Success = true, Result = entities };
    }

    public override async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        var entity = await _context.Events
            .Include(ep => ep.Packages)
            .ThenInclude(p => p.Package)
            .FirstOrDefaultAsync(expression);

        return new RepositoryResult<EventEntity?> { Success = true, Result = entity };
    }
}
