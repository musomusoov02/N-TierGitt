using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.GroupRoom;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class GroupRoomController : ApiController
{
    private readonly IGroupRoomService _groupRoomService;

    public GroupRoomController(IGroupRoomService groupRoomService)
    {
        _groupRoomService = groupRoomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<GroupRoomResponseModel>>.Success(await _groupRoomService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateGroupRoomModel createGroupRoomModel)
    {
        return Ok(ApiResult<CreateGroupRoomResponseModel>.Success(
            await _groupRoomService.CreateAsync(createGroupRoomModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateGroupRoomModel updateGroupRoomModel)
    {
        return Ok(ApiResult<UpdateGroupRoomResponseModel>.Success(
            await _groupRoomService.UpdateAsync(id, updateGroupRoomModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _groupRoomService.DeleteAsync(id)));
    }
}
