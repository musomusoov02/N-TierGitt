using N_Tier.Application.Models.Event;
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

public class EventService : IEventService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository, IMapper mapper, IClaimService claimService)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<EventResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var events = await _eventRepository.GetAllAsync(ev => ev.Id == ev.Id);

        return _mapper.Map<IEnumerable<EventResponseModel>>(events);
    }

    public async Task<CreateEventResponseModel> CreateAsync(CreateEventModel createEventModel)
    {
        var eventEntity = _mapper.Map<Event>(createEventModel);

        var addedEvent = await _eventRepository.AddAsync(eventEntity);

        return new CreateEventResponseModel
        {
            Id = addedEvent.Id
        };
    }

    public async Task<UpdateEventResponseModel> UpdateAsync(Guid id, UpdateEventModel updateEventModel)
    {
        var eventEntity = await _eventRepository.GetFirstAsync(ev => ev.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != eventEntity.CreatedBy)
        //    throw new BadRequestException("The selected event does not belong to you");

        eventEntity.Subject = updateEventModel.Subject;
        eventEntity.StarTime = updateEventModel.StarTime;
        eventEntity.EndTime = updateEventModel.EndTime;
        eventEntity.EventGuest = updateEventModel.EventGuest;

        return new UpdateEventResponseModel
        {
            Id = (await _eventRepository.UpdateAsync(eventEntity)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var eventEntity = await _eventRepository.GetFirstAsync(ev => ev.Id == id);

        return new BaseResponseModel
        {
            Id = (await _eventRepository.DeleteAsync(eventEntity)).Id
        };
    }
}
