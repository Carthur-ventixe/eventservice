using WebApi.Data.Contexts;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
}
