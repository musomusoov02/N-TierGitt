using N_Tier.Application.Models.GroupRoom;
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

public class GroupRoomService : IGroupRoomService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IGroupRoomRepository _groupRoomRepository;

    public GroupRoomService(IGroupRoomRepository groupRoomRepository, IMapper mapper, IClaimService claimService)
    {
        _groupRoomRepository = groupRoomRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<GroupRoomResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var groupRooms = await _groupRoomRepository.GetAllAsync(gr => gr.Id == gr.Id);

        return _mapper.Map<IEnumerable<GroupRoomResponseModel>>(groupRooms);
    }

    public async Task<CreateGroupRoomResponseModel> CreateAsync(CreateGroupRoomModel createGroupRoomModel)
    {
        var groupRoom = _mapper.Map<GroupRoom>(createGroupRoomModel);

        var addedGroupRoom = await _groupRoomRepository.AddAsync(groupRoom);

        return new CreateGroupRoomResponseModel
        {
            Id = addedGroupRoom.Id
        };
    }

    public async Task<UpdateGroupRoomResponseModel> UpdateAsync(Guid id, UpdateGroupRoomModel updateGroupRoomModel)
    {
        var groupRoom = await _groupRoomRepository.GetFirstAsync(gr => gr.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != groupRoom.CreatedBy)
        //    throw new BadRequestException("The selected group room does not belong to you");

        groupRoom.LessonId = updateGroupRoomModel.LessonId;
        groupRoom.TeacherId = updateGroupRoomModel.TeacherId;
        groupRoom.RoomId = updateGroupRoomModel.RoomId;
        groupRoom.GroupId = updateGroupRoomModel.GroupId;
        groupRoom.StarTime = updateGroupRoomModel.StarTime;
        groupRoom.EndTime = updateGroupRoomModel.EndTime;

        return new UpdateGroupRoomResponseModel
        {
            Id = (await _groupRoomRepository.UpdateAsync(groupRoom)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var groupRoom = await _groupRoomRepository.GetFirstAsync(gr => gr.Id == id);

        return new BaseResponseModel
        {
            Id = (await _groupRoomRepository.DeleteAsync(groupRoom)).Id
        };
    }
}
