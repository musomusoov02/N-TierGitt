﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class StudentController : ApiController
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<StudentResponseModel>>.Success(await _studentService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateStudentModel createStudentModel)
    {
        return Ok(ApiResult<CreateStudentResponseModel>.Success(
            await _studentService.CreateAsync(createStudentModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel)
    {
        return Ok(ApiResult<UpdateStudentResponseModel>.Success(
            await _studentService.UpdateAsync(id, updateStudentModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _studentService.DeleteAsync(id)));
    }
}
