using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.GroupRoom;

public class GroupRoomResponseModel : BaseResponseModel
{
    public int LessonId { get; set; }
    public int TeacherId { get; set; }
    public int GroupId { get; set; }
    public int RoomId { get; set; }
    public DateTime StarTime { get; set; } = DateTime.Now;
    public DateTime? EndTime { get; set; }
}
