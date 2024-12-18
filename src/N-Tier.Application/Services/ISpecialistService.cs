using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Specialist;

namespace N_Tier.Application.Services;

public interface ISpecialistService
{
    Task<CreateSpecialistResponseModel> CreateAsync(CreateSpecialistModel createSpecialistModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<SpecialistResponseModel>> GetAllAsync();

    Task<UpdateSpecialistResponseModel> UpdateAsync(Guid id, UpdateSpecialistModel updateSpecialistModel);
}

