using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Specialist;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class SpecialistController : ApiController
{
    private readonly ISpecialistService _specialistService;

    public SpecialistController(ISpecialistService specialistService)
    {
        _specialistService = specialistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<SpecialistResponseModel>>.Success(await _specialistService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSpecialistModel createSpecialistModel)
    {
        return Ok(ApiResult<CreateSpecialistResponseModel>.Success(
            await _specialistService.CreateAsync(createSpecialistModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateSpecialistModel updateSpecialistModel)
    {
        return Ok(ApiResult<UpdateSpecialistResponseModel>.Success(
            await _specialistService.UpdateAsync(id, updateSpecialistModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _specialistService.DeleteAsync(id)));
    }
}
