using N_Tier.Application.Models.EventRoom;
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

public class EventRoomService : IEventRoomService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IEventRoomRepository _eventRoomRepository;

    public EventRoomService(IEventRoomRepository eventRoomRepository, IMapper mapper, IClaimService claimService)
    {
        _eventRoomRepository = eventRoomRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<EventRoomResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var eventRooms = await _eventRoomRepository.GetAllAsync(er => er.Id == er.Id);

        return _mapper.Map<IEnumerable<EventRoomResponseModel>>(eventRooms);
    }

    public async Task<CreateEventRoomResponseModel> CreateAsync(CreateEventRoomModel createEventRoomModel)
    {
        var eventRoom = _mapper.Map<EventRoom>(createEventRoomModel);

        var addedEventRoom = await _eventRoomRepository.AddAsync(eventRoom);

        return new CreateEventRoomResponseModel
        {
            Id = addedEventRoom.Id
        };
    }

    public async Task<UpdateEventRoomResponseModel> UpdateAsync(Guid id, UpdateEventRoomModel updateEventRoomModel)
    {
        var eventRoom = await _eventRoomRepository.GetFirstAsync(er => er.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != eventRoom.CreatedBy)
        //    throw new BadRequestException("The selected event room does not belong to you");

        eventRoom.EventId = updateEventRoomModel.EventId;
        eventRoom.RoomId = updateEventRoomModel.RoomId;
        eventRoom.NumberOfPlaces = updateEventRoomModel.NumberOfPlaces;

        return new UpdateEventRoomResponseModel
        {
            Id = (await _eventRoomRepository.UpdateAsync(eventRoom)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var eventRoom = await _eventRoomRepository.GetFirstAsync(er => er.Id == id);

        return new BaseResponseModel
        {
            Id = (await _eventRoomRepository.DeleteAsync(eventRoom)).Id
        };
    }
}
