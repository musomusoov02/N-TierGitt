using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamGroup;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class ExamGroupController : ApiController
{
    private readonly IExamGroupService _examGroupService;

    public ExamGroupController(IExamGroupService examGroupService)
    {
        _examGroupService = examGroupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<ExamGroupResponseModel>>.Success(await _examGroupService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExamGroupModel createExamGroupModel)
    {
        return Ok(ApiResult<CreateExamGroupResponseModel>.Success(
            await _examGroupService.CreateAsync(createExamGroupModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamGroupModel updateExamGroupModel)
    {
        return Ok(ApiResult<UpdateExamGroupResponseModel>.Success(
            await _examGroupService.UpdateAsync(id, updateExamGroupModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _examGroupService.DeleteAsync(id)));
    }
}
