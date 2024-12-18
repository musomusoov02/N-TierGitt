using N_Tier.Application.Models.ExamGroup;
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

public class ExamGroupService : IExamGroupService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IExamGroupRepository _examGroupRepository;

    public ExamGroupService(IExamGroupRepository examGroupRepository, IMapper mapper, IClaimService claimService)
    {
        _examGroupRepository = examGroupRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<ExamGroupResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var examGroups = await _examGroupRepository.GetAllAsync(eg => eg.Id == eg.Id);

        return _mapper.Map<IEnumerable<ExamGroupResponseModel>>(examGroups);
    }

    public async Task<CreateExamGroupResponseModel> CreateAsync(CreateExamGroupModel createExamGroupModel)
    {
        var examGroup = _mapper.Map<ExamGroup>(createExamGroupModel);

        var addedExamGroup = await _examGroupRepository.AddAsync(examGroup);

        return new CreateExamGroupResponseModel
        {
            Id = addedExamGroup.Id
        };
    }

    public async Task<UpdateExamGroupResponseModel> UpdateAsync(Guid id, UpdateExamGroupModel updateExamGroupModel)
    {
        var examGroup = await _examGroupRepository.GetFirstAsync(eg => eg.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != examGroup.CreatedBy)
        //    throw new BadRequestException("The selected exam group does not belong to you");

        examGroup.ExamId = updateExamGroupModel.ExamId;
        examGroup.GroupId = updateExamGroupModel.GroupId;

        return new UpdateExamGroupResponseModel
        {
            Id = (await _examGroupRepository.UpdateAsync(examGroup)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var examGroup = await _examGroupRepository.GetFirstAsync(eg => eg.Id == id);

        return new BaseResponseModel
        {
            Id = (await _examGroupRepository.DeleteAsync(examGroup)).Id
        };
    }
}
