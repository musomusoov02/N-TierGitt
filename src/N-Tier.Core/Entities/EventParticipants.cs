using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class EventParticipants : BaseEntity
{
    public int PersonId { get; set; }
    public Person? Person { get; set; }

    public int EventId { get; set; }
    public Event? Event { get; set; }
}
