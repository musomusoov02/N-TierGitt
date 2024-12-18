﻿using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Repositories.Impl;

public class StudentRepository :BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(DatabaseContext context) : base(context) { }

}
