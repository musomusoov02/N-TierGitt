using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Lesson;

namespace N_Tier.Application.Services;

public interface ILessonService
{
    Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<LessonResponseModel>> GetAllAsync();

    Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel);
}

