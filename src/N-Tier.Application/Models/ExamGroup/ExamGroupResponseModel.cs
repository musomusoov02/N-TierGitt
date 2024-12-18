using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamGroup
{
    public class ExamGroupResponseModel : BaseResponseModel
    {   
        public int ExamId { get; set; }
        public int GroupId { get; set; }
    }
}
