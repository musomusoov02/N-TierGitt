using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Event;

namespace N_Tier.Application.Services;

public interface IEventService
{
    Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<EventResponseModel>> GetAllAsync();

    Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel);
}

