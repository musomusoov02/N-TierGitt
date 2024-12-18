﻿using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Student
{
    public class UpdateStudentModel
    {
        public Person Person { get; set; }
        public int GroupId { get; set; }
    }
    public class UpdateStudentResponseModel : BaseResponseModel { }
}
