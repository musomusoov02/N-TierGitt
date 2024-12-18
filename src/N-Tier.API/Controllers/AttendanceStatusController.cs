using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.AttendanceStatus;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class AttendanceStatusController : ApiController
{
    private readonly IAttendanceStatusService _attendanceStatusService;

    public AttendanceStatusController(IAttendanceStatusService attendanceStatusService)
    {
        _attendanceStatusService = attendanceStatusService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<AttendanceStatusResponseModel>>.Success(await _attendanceStatusService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAttendanceStatusModel createAttendanceStatusModel)
    {
        return Ok(ApiResult<CreateAttendanceStatusResponseModel>.Success(
            await _attendanceStatusService.CreateAsync(createAttendanceStatusModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateAttendanceStatusModel updateAttendanceStatusModel)
    {
        return Ok(ApiResult<UpdateAttendanceStatusResponseModel>.Success(
            await _attendanceStatusService.UpdateAsync(id, updateAttendanceStatusModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _attendanceStatusService.DeleteAsync(id)));
    }
}
