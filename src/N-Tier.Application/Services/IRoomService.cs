using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Room;

namespace N_Tier.Application.Services;

public interface IRoomService
{
    Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<RoomResponseModel>> GetAllAsync();

    Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel);
}
