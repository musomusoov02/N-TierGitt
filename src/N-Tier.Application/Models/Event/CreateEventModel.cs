using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Event
{
    public class CreateEventModel
    {
        public string Subject { get; set; }
        public string EventGuest { get; set; }
        public DateTime StarTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
    }

    public class CreateEventResponseModel : BaseResponseModel { }
}
