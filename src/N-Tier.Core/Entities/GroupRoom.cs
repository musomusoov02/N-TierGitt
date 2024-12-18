using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class GroupRoom : BaseEntity
{
    public int LessonId { get; set; }
    public Lesson? Lesson { get; set; }
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public DateTime StarTime { get; set; }
    public DateTime? EndTime { get; set; }
}
