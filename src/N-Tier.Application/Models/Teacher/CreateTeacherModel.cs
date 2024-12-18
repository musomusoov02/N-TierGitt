﻿using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Teacher;

public class CreateTeacherModel
{
    public Person Person { get; set; }
    public int SpecialistId { get; set; }
}

public class CreateTeacherResponseModel : BaseResponseModel { }

