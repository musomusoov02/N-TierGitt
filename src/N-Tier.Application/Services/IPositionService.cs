using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Position;

namespace N_Tier.Application.Services;

public interface IPositionService
{
    Task<CreatePositionResponseModel> CreateAsync(CreatePositionModel createPositionModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<PositionResponseModel>> GetAllAsync();

    Task<UpdatePositionResponseModel> UpdateAsync(Guid id, UpdatePositionModel updatePositionModel);
}
