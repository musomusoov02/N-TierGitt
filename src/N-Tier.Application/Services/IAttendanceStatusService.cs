using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.AttendanceStatus;

namespace N_Tier.Application.Services;

public interface IAttendanceStatusService
{
    Task<CreateAttendanceStatusResponseModel> CreateAsync(CreateAttendanceStatusModel createAttendanceStatusModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<AttendanceStatusResponseModel>> GetAllAsync();

    Task<UpdateAttendanceStatusResponseModel> UpdateAsync(Guid id, UpdateAttendanceStatusModel updateAttendanceStatusModel);
}
