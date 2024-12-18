using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Position;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers;

//[Authorize]
public class PositionController : ApiController
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<PositionResponseModel>>.Success(await _positionService.GetAllAsync()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePositionModel createPositionModel)
    {
        return Ok(ApiResult<CreatePositionResponseModel>.Success(
            await _positionService.CreateAsync(createPositionModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdatePositionModel updatePositionModel)
    {
        return Ok(ApiResult<UpdatePositionResponseModel>.Success(
            await _positionService.UpdateAsync(id, updatePositionModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _positionService.DeleteAsync(id)));
    }
}
