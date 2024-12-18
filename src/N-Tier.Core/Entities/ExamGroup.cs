using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class ExamGroup :BaseEntity
{

    public int ExamId { get; set; }
    public Exam? Exam { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
