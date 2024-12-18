using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class ExamGroupRoom:BaseEntity
{
    public int ExamGroupId { get; set; }
    public ExamGroup? ExamGroup { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
}
