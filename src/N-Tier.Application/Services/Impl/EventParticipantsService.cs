using N_Tier.Application.Models.EventParticipants;
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

public class EventParticipantsService : IEventParticipantsService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IEventParticipantsRepository _eventParticipantsRepository;

    public EventParticipantsService(IEventParticipantsRepository eventParticipantsRepository, IMapper mapper, IClaimService claimService)
    {
        _eventParticipantsRepository = eventParticipantsRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<EventParticipantsResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var eventParticipants = await _eventParticipantsRepository.GetAllAsync(ep => ep.Id == ep.Id);

        return _mapper.Map<IEnumerable<EventParticipantsResponseModel>>(eventParticipants);
    }

    public async Task<CreateEventParticipantsResponseModel> CreateAsync(CreateEventParticipantsModel createEventParticipantsModel)
    {
        var eventParticipants = _mapper.Map<EventParticipants>(createEventParticipantsModel);

        var addedEventParticipants = await _eventParticipantsRepository.AddAsync(eventParticipants);

        return new CreateEventParticipantsResponseModel
        {
            Id = addedEventParticipants.Id
        };
    }

    public async Task<UpdateEventParticipantsResponseModel> UpdateAsync(Guid id, UpdateEventParticipantsModel updateEventParticipantsModel)
    {
        var eventParticipants = await _eventParticipantsRepository.GetFirstAsync(ep => ep.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != eventParticipants.CreatedBy)
        //    throw new BadRequestException("The selected participant list does not belong to you");

        eventParticipants.Person = updateEventParticipantsModel.Person;
        eventParticipants.EventId = updateEventParticipantsModel.EventId;

        return new UpdateEventParticipantsResponseModel
        {
            Id = (await _eventParticipantsRepository.UpdateAsync(eventParticipants)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var eventParticipants = await _eventParticipantsRepository.GetFirstAsync(ep => ep.Id == id);

        return new BaseResponseModel
        {
            Id = (await _eventParticipantsRepository.DeleteAsync(eventParticipants)).Id
        };
    }
}
