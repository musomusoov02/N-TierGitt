using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.EventParticipants;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class EventParticipantsController : ApiController
{
    private readonly IEventParticipantsService _eventParticipantsService;

    public EventParticipantsController(IEventParticipantsService eventParticipantsService)
    {
        _eventParticipantsService = eventParticipantsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<EventParticipantsResponseModel>>.Success(await _eventParticipantsService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEventParticipantsModel createEventParticipantsModel)
    {
        return Ok(ApiResult<CreateEventParticipantsResponseModel>.Success(
            await _eventParticipantsService.CreateAsync(createEventParticipantsModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventParticipantsModel updateEventParticipantsModel)
    {
        return Ok(ApiResult<UpdateEventParticipantsResponseModel>.Success(
            await _eventParticipantsService.UpdateAsync(id, updateEventParticipantsModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _eventParticipantsService.DeleteAsync(id)));
    }
}
