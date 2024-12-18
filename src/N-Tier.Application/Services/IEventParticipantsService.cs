using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.EventParticipants;

namespace N_Tier.Application.Services;

public interface IEventParticipantsService
{
    Task<CreateEventParticipantsResponseModel> CreateAsync(CreateEventParticipantsModel createEventParticipantsModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<EventParticipantsResponseModel>> GetAllAsync();

    Task<UpdateEventParticipantsResponseModel> UpdateAsync(Guid id, UpdateEventParticipantsModel updateEventParticipantsModel);
}
