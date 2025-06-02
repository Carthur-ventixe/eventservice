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
            StartPrice = model.StartPrice,
            Packages = model.EventPackages.Select(x => new EventPackageEntity
            {
                PackageId = x.PackageId,
                Price = x.PackagePrice
            }).ToList(),
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
            StartPrice = entity.StartPrice,
            Packages = entity.Packages.Select(x => new PackageModel
            {
                Id = x.Package.Id,
                Title = x.Package.Title,
                Position = x.Package.Position,
                Placement = x.Package.Placement,
                Price = x.Price,
            })
        };
    }
}
