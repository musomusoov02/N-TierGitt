using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Common;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Repositories.Impl;

public class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(DatabaseContext context) : base(context) { }
}
