using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.ExamGroupRoom;

namespace N_Tier.Application.Services;

public interface IExamGroupRoomService
{
    Task<CreateExamGroupRoomResponseModel> CreateAsync(CreateExamGroupRoomModel createExamGroupRoomModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<ExamGroupRoomResponseModel>> GetAllAsync();

    Task<UpdateExamGroupRoomResponseModel> UpdateAsync(Guid id, UpdateExamGroupRoomModel updateExamGroupRoomModel);
}

