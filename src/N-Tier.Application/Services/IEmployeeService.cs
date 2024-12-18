using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Employee;

namespace N_Tier.Application.Services;

public interface IEmployeeService
{
    Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<EmployeeResponseModel>> GetAllAsync();

    Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel);
}
