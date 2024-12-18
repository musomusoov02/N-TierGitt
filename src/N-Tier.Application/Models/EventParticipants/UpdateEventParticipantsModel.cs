using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.EventParticipants;

public class UpdateEventParticipantsModel
{
    public Person Person { get; set; }
    public int EventId { get; set; }
}
public class UpdateEventParticipantsResponseModel : BaseResponseModel { }
