using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Group;

namespace N_Tier.Application.Services;

public interface IGroupService
{
    Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<GroupResponseModel>> GetAllAsync();

    Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel);
}
