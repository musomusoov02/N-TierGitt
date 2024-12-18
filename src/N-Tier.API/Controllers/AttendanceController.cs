using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class AttendanceController : ApiController
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<AttendanceResponseModel>>.Success(await _attendanceService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAttendanceModel createAttendanceModel)
    {
        return Ok(ApiResult<CreateAttendanceResponseModel>.Success(
            await _attendanceService.CreateAsync(createAttendanceModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel)
    {
        return Ok(ApiResult<UpdateAttendanceResponseModel>.Success(
            await _attendanceService.UpdateAsync(id, updateAttendanceModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _attendanceService.DeleteAsync(id)));
    }
}
