using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.ExamBall;

namespace N_Tier.Application.Services;

public interface IExamBallService
{
    Task<CreateExamBallResponseModel> CreateAsync(CreateExamBallModel createExamBallModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<ExamBallResponseModel>> GetAllAsync();

    Task<UpdateExamBallResponseModel> UpdateAsync(Guid id, UpdateExamBallModel updateExamBallModel);
}

