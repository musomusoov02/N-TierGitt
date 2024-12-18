using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Student;

namespace N_Tier.Application.Services;

public interface IStudentService
{
    Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<StudentResponseModel>> GetAllAsync();

    Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel);
}
