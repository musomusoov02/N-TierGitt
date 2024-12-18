using N_Tier.Application.Models.Exam;
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

public class ExamService : IExamService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IExamRepository _examRepository;

    public ExamService(IExamRepository examRepository, IMapper mapper, IClaimService claimService)
    {
        _examRepository = examRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<ExamResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var exams = await _examRepository.GetAllAsync(exam => exam.Id == exam.Id);

        return _mapper.Map<IEnumerable<ExamResponseModel>>(exams);
    }

    public async Task<CreateExamResponseModel> CreateAsync(CreateExamModel createExamModel)
    {
        var exam = _mapper.Map<Exam>(createExamModel);

        var addedExam = await _examRepository.AddAsync(exam);

        return new CreateExamResponseModel
        {
            Id = addedExam.Id
        };
    }

    public async Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel)
    {
        var exam = await _examRepository.GetFirstAsync(exam => exam.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != exam.CreatedBy)
        //    throw new BadRequestException("The selected exam does not belong to you");

        exam.Subject = updateExamModel.Subject;
        exam.SuperVisor = updateExamModel.SuperVisor;
        exam.QuestionsCount = updateExamModel.QuestionsCount;
        exam.TotalScore = updateExamModel.TotalScore;
        exam.StarTime = updateExamModel.StarTime;
        exam.EndTime = updateExamModel.EndTime;

        return new UpdateExamResponseModel
        {
            Id = (await _examRepository.UpdateAsync(exam)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var exam = await _examRepository.GetFirstAsync(exam => exam.Id == id);

        return new BaseResponseModel
        {
            Id = (await _examRepository.DeleteAsync(exam)).Id
        };
    }
}
