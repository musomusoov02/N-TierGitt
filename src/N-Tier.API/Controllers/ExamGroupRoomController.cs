using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamGroupRoom;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class ExamGroupRoomController : ApiController
{
    private readonly IExamGroupRoomService _examGroupRoomService;

    public ExamGroupRoomController(IExamGroupRoomService examGroupRoomService)
    {
        _examGroupRoomService = examGroupRoomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<ExamGroupRoomResponseModel>>.Success(await _examGroupRoomService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExamGroupRoomModel createExamGroupRoomModel)
    {
        return Ok(ApiResult<CreateExamGroupRoomResponseModel>.Success(
            await _examGroupRoomService.CreateAsync(createExamGroupRoomModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamGroupRoomModel updateExamGroupRoomModel)
    {
        return Ok(ApiResult<UpdateExamGroupRoomResponseModel>.Success(
            await _examGroupRoomService.UpdateAsync(id, updateExamGroupRoomModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _examGroupRoomService.DeleteAsync(id)));
    }
}
