using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class RoomController : ApiController
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<RoomResponseModel>>.Success(await _roomService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRoomModel createRoomModel)
    {
        return Ok(ApiResult<CreateRoomResponseModel>.Success(
            await _roomService.CreateAsync(createRoomModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel)
    {
        return Ok(ApiResult<UpdateRoomResponseModel>.Success(
            await _roomService.UpdateAsync(id, updateRoomModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _roomService.DeleteAsync(id)));
    }
}
