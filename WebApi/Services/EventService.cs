using System.Linq.Expressions;
using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Factories;
using WebApi.Models;

namespace WebApi.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateAsync(CreateEventModel model)
    {
        var entity = EventFactory.CreateEntity(model);

        var result = await _eventRepository.AddAsync(entity);

        if (!result.Success)
            return new EventResult { Success = false, Error = "Could not create event" };

        return new EventResult { Success = true, };
    }

    public async Task<EventResult<IEnumerable<EventModel>>> GetEventsAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        var events = result.Result?.Select(EventFactory.CreateModel);

        return new EventResult<IEnumerable<EventModel>> { Success = true, Result = events };
    }

    public async Task<EventResult<EventModel?>> GetEventAsync(Expression<Func<EventEntity, bool>> expression)
    {
        var result = await _eventRepository.GetAsync(expression);

        if (result.Success && result.Result != null)
        {
            var eventModel = EventFactory.CreateModel(result.Result);
            return new EventResult<EventModel?> { Success = true, Result = eventModel };

        }

        return new EventResult<EventModel?> { Success = false, Error = "NotFound" };
    }
}
