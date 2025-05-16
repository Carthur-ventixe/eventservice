using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _eventService.CreateAsync(model);
        if (!result.Success)
            return StatusCode(500, result.Error);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _eventService.GetEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var currentEvent = await _eventService.GetEventAsync(x => x.Id == id);

        if (currentEvent.Result == null)
            return NotFound();

        return Ok(currentEvent);
    }
}
