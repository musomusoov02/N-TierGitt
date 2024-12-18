using N_Tier.Application.Models.Room;
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

public class RoomService : IRoomService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository, IMapper mapper, IClaimService claimService)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<RoomResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var rooms = await _roomRepository.GetAllAsync(room => room.Id == room.Id);

        return _mapper.Map<IEnumerable<RoomResponseModel>>(rooms);
    }

    public async Task<CreateRoomResponseModel> CreateAsync(CreateRoomModel createRoomModel)
    {
        var room = _mapper.Map<Room>(createRoomModel);

        var addedRoom = await _roomRepository.AddAsync(room);

        return new CreateRoomResponseModel
        {
            Id = addedRoom.Id
        };
    }

    public async Task<UpdateRoomResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel)
    {
        var room = await _roomRepository.GetFirstAsync(room => room.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != room.CreatedBy)
        //    throw new BadRequestException("The selected room does not belong to you");

        room.Name = updateRoomModel.Name;
        room.RoomNumber = updateRoomModel.RoomNumber;

        return new UpdateRoomResponseModel
        {
            Id = (await _roomRepository.UpdateAsync(room)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var room = await _roomRepository.GetFirstAsync(room => room.Id == id);

        return new BaseResponseModel
        {
            Id = (await _roomRepository.DeleteAsync(room)).Id
        };
    }
}
