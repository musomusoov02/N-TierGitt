using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Repositories.Impl;

public class SpecialistRepository : BaseRepository<Specialist>, ISpecialistRepository
{
    public SpecialistRepository(DatabaseContext context) : base(context) { }
}
