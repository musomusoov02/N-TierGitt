using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class ExamController : ApiController
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<ExamResponseModel>>.Success(await _examService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExamModel createExamModel)
    {
        return Ok(ApiResult<CreateExamResponseModel>.Success(
            await _examService.CreateAsync(createExamModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamModel updateExamModel)
    {
        return Ok(ApiResult<UpdateExamResponseModel>.Success(
            await _examService.UpdateAsync(id, updateExamModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _examService.DeleteAsync(id)));
    }
}
