using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class EventController : ApiController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<EventResponseModel>>.Success(await _eventService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEventModel createEventModel)
    {
        return Ok(ApiResult<CreateEventResponseModel>.Success(
            await _eventService.CreateAsync(createEventModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventModel updateEventModel)
    {
        return Ok(ApiResult<UpdateEventResponseModel>.Success(
            await _eventService.UpdateAsync(id, updateEventModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _eventService.DeleteAsync(id)));
    }
}
