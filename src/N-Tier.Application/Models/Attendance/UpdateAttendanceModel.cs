using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Attendance;

public class UpdateAttendanceModel
{
    public int StudentId { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public int AttendanceStatusId { get; set; }

}
public class UpdateAttendanceResponseModel : BaseResponseModel { }
