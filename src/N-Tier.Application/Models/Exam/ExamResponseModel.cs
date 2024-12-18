using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Exam;

public class ExamResponseModel : BaseResponseModel
{
    public int QuestionsCount { get; set; }
    public string Subject { get; set; }
    public int TotalScore { get; set; }
    public string SuperVisor { get; set; }
    public DateTime StarTime { get; set; }
    public DateTime? EndTime { get; set; }
}
