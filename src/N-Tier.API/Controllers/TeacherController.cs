using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Teacher;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class TeacherController : ApiController
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<TeacherResponseModel>>.Success(await _teacherService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTeacherModel createTeacherModel)
    {
        return Ok(ApiResult<CreateTeacherResponseModel>.Success(
            await _teacherService.CreateAsync(createTeacherModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel)
    {
        return Ok(ApiResult<UpdateTeacherResponseModel>.Success(
            await _teacherService.UpdateAsync(id, updateTeacherModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _teacherService.DeleteAsync(id)));
    }
}
