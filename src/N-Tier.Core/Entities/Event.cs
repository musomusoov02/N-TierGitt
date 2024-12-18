using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Event : BaseEntity
{
    public string Subject { get; set; }
    public string EventGuest { get; set; }
    public DateTime StarTime { get; set; }
    public DateTime? EndTime { get; set; }
    
}
