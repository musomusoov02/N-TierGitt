using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class EmployeeController : ApiController
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<EmployeeResponseModel>>.Success(await _employeeService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        return Ok(ApiResult<CreateEmployeeResponseModel>.Success(
            await _employeeService.CreateAsync(createEmployeeModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        return Ok(ApiResult<UpdateEmployeeResponseModel>.Success(
            await _employeeService.UpdateAsync(id, updateEmployeeModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _employeeService.DeleteAsync(id)));
    }
}
