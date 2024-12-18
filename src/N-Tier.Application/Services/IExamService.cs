using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Exam;

namespace N_Tier.Application.Services;

public interface IExamService
{
    Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<ExamResponseModel>> GetAllAsync();

    Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel);
}

