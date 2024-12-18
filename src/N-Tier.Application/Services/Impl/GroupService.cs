using N_Tier.Application.Models.Group;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using N_Tier.Application.Exceptions;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl;

public class GroupService : IGroupService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository, IMapper mapper, IClaimService claimService)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<GroupResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var groups = await _groupRepository.GetAllAsync(group => group.Id == group.Id);

        return _mapper.Map<IEnumerable<GroupResponseModel>>(groups);
    }

    public async Task<CreateGroupResponseModel> CreateAsync(CreateGroupModel createGroupModel)
    {
        var group = _mapper.Map<Group>(createGroupModel);

        var addedGroup = await _groupRepository.AddAsync(group);

        return new CreateGroupResponseModel
        {
            Id = addedGroup.Id
        };
    }

    public async Task<UpdateGroupResponseModel> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel)
    {
        var group = await _groupRepository.GetFirstAsync(group => group.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != group.CreatedBy)
        //    throw new BadRequestException("The selected group does not belong to you");

        group.Name = updateGroupModel.Name;

        return new UpdateGroupResponseModel
        {
            Id = (await _groupRepository.UpdateAsync(group)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var group = await _groupRepository.GetFirstAsync(group => group.Id == id);

        return new BaseResponseModel
        {
            Id = (await _groupRepository.DeleteAsync(group)).Id
        };
    }
}
