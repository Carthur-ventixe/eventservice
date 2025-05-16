using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Factories;

public static class EventFactory
{
    public static EventEntity CreateEntity(CreateEventModel model)
    {
        return new EventEntity
        {
            Title = model.Title,
            EventDate = model.EventDate,
            Description = model.Description,
            Image = model.Image,
            Location = model.Location,
            Price = model.Price,
        };
    }

    public static EventModel CreateModel(EventEntity entity)
    {
        return new EventModel
        {
            Id = entity.Id,
            Title = entity.Title,
            EventDate = entity.EventDate,
            Description = entity.Description,
            Image = entity.Image,
            Location = entity.Location,
            Price = entity.Price,
        };
    }
}
