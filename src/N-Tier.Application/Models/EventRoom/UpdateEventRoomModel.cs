using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.EventRoom;

public class UpdateEventRoomModel
{
    public int EventId { get; set; }
    public int RoomId { get; set; }
    public int NumberOfPlaces { get; set; }
}
public class UpdateEventRoomResponseModel : BaseResponseModel { }
