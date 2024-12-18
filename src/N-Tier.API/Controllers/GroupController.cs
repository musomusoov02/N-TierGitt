using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class GroupController : ApiController
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<GroupResponseModel>>.Success(await _groupService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateGroupModel createGroupModel)
    {
        return Ok(ApiResult<CreateGroupResponseModel>.Success(
            await _groupService.CreateAsync(createGroupModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel)
    {
        return Ok(ApiResult<UpdateGroupResponseModel>.Success(
            await _groupService.UpdateAsync(id, updateGroupModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _groupService.DeleteAsync(id)));
    }
}
