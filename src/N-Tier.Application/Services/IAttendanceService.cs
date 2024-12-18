using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Attendance;

namespace N_Tier.Application.Services;

public interface IAttendanceService
{
    Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<AttendanceResponseModel>> GetAllAsync();

    Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel);
}
