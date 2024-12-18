using N_Tier.Application.Models.Teacher;
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

public class TeacherService : ITeacherService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper, IClaimService claimService)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<TeacherResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var teachers = await _teacherRepository.GetAllAsync(teacher => teacher.Id == teacher.Id);

        return _mapper.Map<IEnumerable<TeacherResponseModel>>(teachers);
    }

    public async Task<CreateTeacherResponseModel> CreateAsync(CreateTeacherModel createTeacherModel)
    {
        var teacher = _mapper.Map<Teacher>(createTeacherModel);

        var addedTeacher = await _teacherRepository.AddAsync(teacher);

        return new CreateTeacherResponseModel
        {
            Id = addedTeacher.Id
        };
    }

    public async Task<UpdateTeacherResponseModel> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel)
    {
        var teacher = await _teacherRepository.GetFirstAsync(teacher => teacher.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != teacher.CreatedBy)
        //    throw new BadRequestException("The selected teacher does not belong to you");

        teacher.SpecialistId = updateTeacherModel.SpecialistId;
        teacher.Person = updateTeacherModel.Person;

        return new UpdateTeacherResponseModel
        {
            Id = (await _teacherRepository.UpdateAsync(teacher)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetFirstAsync(teacher => teacher.Id == id);

        return new BaseResponseModel
        {
            Id = (await _teacherRepository.DeleteAsync(teacher)).Id
        };
    }
}
