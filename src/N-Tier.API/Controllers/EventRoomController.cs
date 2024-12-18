using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.EventRoom;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class EventRoomController : ApiController
{
    private readonly IEventRoomService _eventRoomService;

    public EventRoomController(IEventRoomService eventRoomService)
    {
        _eventRoomService = eventRoomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<EventRoomResponseModel>>.Success(await _eventRoomService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEventRoomModel createEventRoomModel)
    {
        return Ok(ApiResult<CreateEventRoomResponseModel>.Success(
            await _eventRoomService.CreateAsync(createEventRoomModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventRoomModel updateEventRoomModel)
    {
        return Ok(ApiResult<UpdateEventRoomResponseModel>.Success(
            await _eventRoomService.UpdateAsync(id, updateEventRoomModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _eventRoomService.DeleteAsync(id)));
    }
}
