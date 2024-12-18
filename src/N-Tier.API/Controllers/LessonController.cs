using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class LessonController : ApiController
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<LessonResponseModel>>.Success(await _lessonService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateLessonModel createLessonModel)
    {
        return Ok(ApiResult<CreateLessonResponseModel>.Success(
            await _lessonService.CreateAsync(createLessonModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel)
    {
        return Ok(ApiResult<UpdateLessonResponseModel>.Success(
            await _lessonService.UpdateAsync(id, updateLessonModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _lessonService.DeleteAsync(id)));
    }
}
