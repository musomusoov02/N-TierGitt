using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class ExamBall : BaseEntity
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int ExamId { get; set; }
    public Exam? Exam { get; set; }
    public int Ball { get; set; }
}
