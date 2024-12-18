using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Teacher;

namespace N_Tier.Application.Services;

public interface ITeacherService
{
    Task<CreateTeacherResponseModel> CreateAsync(CreateTeacherModel createTeacherModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<TeacherResponseModel>> GetAllAsync();

    Task<UpdateTeacherResponseModel> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel);
}

