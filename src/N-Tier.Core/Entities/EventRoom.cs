using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class EventRoom : BaseEntity 
{
    public int EventId { get; set; }
    public Event? Event { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public int NumberOfPlaces { get; set; }
    
}
