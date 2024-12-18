using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.EventRoom;

namespace N_Tier.Application.Services;

public interface IEventRoomService
{
    Task<CreateEventRoomResponseModel> CreateAsync(CreateEventRoomModel createEventRoomModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<EventRoomResponseModel>> GetAllAsync();

    Task<UpdateEventRoomResponseModel> UpdateAsync(Guid id, UpdateEventRoomModel updateEventRoomModel);
}

