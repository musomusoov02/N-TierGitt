using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamGroupRoom;

public class CreateExamGroupRoomModel
{
    public int ExamGroupId { get; set; }
    public int RoomId { get; set; }

}

public class CreateExamGroupRoomResponseModel : BaseResponseModel { }

