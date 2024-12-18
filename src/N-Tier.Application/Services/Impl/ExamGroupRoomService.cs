using N_Tier.Application.Models.ExamGroupRoom;
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

public class ExamGroupRoomService : IExamGroupRoomService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IExamGroupRoomRepository _examGroupRoomRepository;

    public ExamGroupRoomService(IExamGroupRoomRepository examGroupRoomRepository, IMapper mapper, IClaimService claimService)
    {
        _examGroupRoomRepository = examGroupRoomRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<ExamGroupRoomResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var examGroupRooms = await _examGroupRoomRepository.GetAllAsync(egr => egr.Id == egr.Id);

        return _mapper.Map<IEnumerable<ExamGroupRoomResponseModel>>(examGroupRooms);
    }

    public async Task<CreateExamGroupRoomResponseModel> CreateAsync(CreateExamGroupRoomModel createExamGroupRoomModel)
    {
        var examGroupRoom = _mapper.Map<ExamGroupRoom>(createExamGroupRoomModel);

        var addedExamGroupRoom = await _examGroupRoomRepository.AddAsync(examGroupRoom);

        return new CreateExamGroupRoomResponseModel
        {
            Id = addedExamGroupRoom.Id
        };
    }

    public async Task<UpdateExamGroupRoomResponseModel> UpdateAsync(Guid id, UpdateExamGroupRoomModel updateExamGroupRoomModel)
    {
        var examGroupRoom = await _examGroupRoomRepository.GetFirstAsync(egr => egr.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != examGroupRoom.CreatedBy)
        //    throw new BadRequestException("The selected exam group room does not belong to you");

        examGroupRoom.ExamGroupId = updateExamGroupRoomModel.ExamGroupId;
        examGroupRoom.RoomId = updateExamGroupRoomModel.RoomId;

        return new UpdateExamGroupRoomResponseModel
        {
            Id = (await _examGroupRoomRepository.UpdateAsync(examGroupRoom)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var examGroupRoom = await _examGroupRoomRepository.GetFirstAsync(egr => egr.Id == id);

        return new BaseResponseModel
        {
            Id = (await _examGroupRoomRepository.DeleteAsync(examGroupRoom)).Id
        };
    }
}
