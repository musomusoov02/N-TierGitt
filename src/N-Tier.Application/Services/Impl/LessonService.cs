using N_Tier.Application.Models.Lesson;
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

public class LessonService : ILessonService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly ILessonRepository _lessonRepository;

    public LessonService(ILessonRepository lessonRepository, IMapper mapper, IClaimService claimService)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<LessonResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var lessons = await _lessonRepository.GetAllAsync(lesson => lesson.Id == lesson.Id);

        return _mapper.Map<IEnumerable<LessonResponseModel>>(lessons);
    }

    public async Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel)
    {
        var lesson = _mapper.Map<Lesson>(createLessonModel);

        var addedLesson = await _lessonRepository.AddAsync(lesson);

        return new CreateLessonResponseModel
        {
            Id = addedLesson.Id
        };
    }

    public async Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel)
    {
        var lesson = await _lessonRepository.GetFirstAsync(lesson => lesson.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != lesson.CreatedBy)
        //    throw new BadRequestException("The selected lesson does not belong to you");

        lesson.Name = updateLessonModel.Name;

        return new UpdateLessonResponseModel
        {
            Id = (await _lessonRepository.UpdateAsync(lesson)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var lesson = await _lessonRepository.GetFirstAsync(lesson => lesson.Id == id);

        return new BaseResponseModel
        {
            Id = (await _lessonRepository.DeleteAsync(lesson)).Id
        };
    }
}
