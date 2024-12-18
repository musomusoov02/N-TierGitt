using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.GroupRoom;

namespace N_Tier.Application.Services;

public interface IGroupRoomService
{
    Task<CreateGroupRoomResponseModel> CreateAsync(CreateGroupRoomModel createGroupRoomModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<GroupRoomResponseModel>> GetAllAsync();

    Task<UpdateGroupRoomResponseModel> UpdateAsync(Guid id, UpdateGroupRoomModel updateGroupRoomModel);
}

