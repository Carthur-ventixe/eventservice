using System.Linq.Expressions;
using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEventService
    {
        Task<EventResult> CreateAsync(CreateEventModel model);
        Task<EventResult<EventModel?>> GetEventAsync(Expression<Func<EventEntity, bool>> expression);
        Task<EventResult<IEnumerable<EventModel>>> GetEventsAsync();
    }
}