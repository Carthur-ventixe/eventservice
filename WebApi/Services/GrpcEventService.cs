using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace WebApi.Services;

public class GrpcEventService(IEventService eventService) : EventContract.EventContractBase
{
    private readonly IEventService _eventService = eventService;

    public override async Task<EventReply> GetEventWithPackageById(EventByIdRequest request, ServerCallContext context)
    {
        var result = await _eventService.GetEventAsync(x => x.Id == request.EventId);
        if (result.Result == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Event not found"));
        }

        var package = result.Result.Packages.FirstOrDefault(x => x.Id == request.PackageId);
        if (package == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Package not found"));
        }

        return new EventReply
        {
            EventName = result.Result.Title,
            PackageName = package.Title,
            EventDate = Timestamp.FromDateTime(result.Result.EventDate.ToUniversalTime()),
            Location = result.Result.Location
        };
    }
}
