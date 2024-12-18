using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamBall;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class ExamBallController : ApiController
{
    private readonly IExamBallService _examBallService;

    public ExamBallController(IExamBallService examBallService)
    {
        _examBallService = examBallService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<ExamBallResponseModel>>.Success(await _examBallService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateExamBallModel createExamBallModel)
    {
        return Ok(ApiResult<CreateExamBallResponseModel>.Success(
            await _examBallService.CreateAsync(createExamBallModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamBallModel updateExamBallModel)
    {
        return Ok(ApiResult<UpdateExamBallResponseModel>.Success(
            await _examBallService.UpdateAsync(id, updateExamBallModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _examBallService.DeleteAsync(id)));
    }
}
