﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ExamBall
{
    public class ExamBallResponseModel : BaseResponseModel
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Ball { get; set; }
    }
}
