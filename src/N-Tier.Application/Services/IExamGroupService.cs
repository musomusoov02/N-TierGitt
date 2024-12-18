using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.ExamGroup;

namespace N_Tier.Application.Services;

public interface IExamGroupService
{
    Task<CreateExamGroupResponseModel> CreateAsync(CreateExamGroupModel createExamGroupModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<ExamGroupResponseModel>> GetAllAsync();

    Task<UpdateExamGroupResponseModel> UpdateAsync(Guid id, UpdateExamGroupModel updateExamGroupModel);
}

