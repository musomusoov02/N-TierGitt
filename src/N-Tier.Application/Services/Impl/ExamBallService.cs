using N_Tier.Application.Models.ExamBall;
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

public class ExamBallService : IExamBallService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IExamBallRepository _examBallRepository;

    public ExamBallService(IExamBallRepository examBallRepository, IMapper mapper, IClaimService claimService)
    {
        _examBallRepository = examBallRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<ExamBallResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var examBalls = await _examBallRepository.GetAllAsync(eb => eb.Id == eb.Id);

        return _mapper.Map<IEnumerable<ExamBallResponseModel>>(examBalls);
    }

    public async Task<CreateExamBallResponseModel> CreateAsync(CreateExamBallModel createExamBallModel)
    {
        var examBall = _mapper.Map<ExamBall>(createExamBallModel);

        var addedExamBall = await _examBallRepository.AddAsync(examBall);

        return new CreateExamBallResponseModel
        {
            Id = addedExamBall.Id
        };
    }

    public async Task<UpdateExamBallResponseModel> UpdateAsync(Guid id, UpdateExamBallModel updateExamBallModel)
    {
        var examBall = await _examBallRepository.GetFirstAsync(eb => eb.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != examBall.CreatedBy)
        //    throw new BadRequestException("The selected exam ball does not belong to you");

        examBall.StudentId = updateExamBallModel.StudentId;
        examBall.ExamId = updateExamBallModel.ExamId;
        examBall.Ball = updateExamBallModel.Ball;

        return new UpdateExamBallResponseModel
        {
            Id = (await _examBallRepository.UpdateAsync(examBall)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var examBall = await _examBallRepository.GetFirstAsync(eb => eb.Id == id);

        return new BaseResponseModel
        {
            Id = (await _examBallRepository.DeleteAsync(examBall)).Id
        };
    }
}
