using N_Tier.Application.Models.Student;
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

public class StudentService : IStudentService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository, IMapper mapper, IClaimService claimService)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<StudentResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var students = await _studentRepository.GetAllAsync(student => student.Id == student.Id);

        return _mapper.Map<IEnumerable<StudentResponseModel>>(students);
    }

    public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel)
    {
        var student = _mapper.Map<Student>(createStudentModel);

        var addedStudent = await _studentRepository.AddAsync(student);

        return new CreateStudentResponseModel
        {
            Id = addedStudent.Id
        };
    }

    public async Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel)
    {
        var student = await _studentRepository.GetFirstAsync(student => student.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != student.CreatedBy)
        //    throw new BadRequestException("The selected student does not belong to you");

        student.Person = updateStudentModel.Person;
        student.GroupId = updateStudentModel.GroupId;

        return new UpdateStudentResponseModel
        {
            Id = (await _studentRepository.UpdateAsync(student)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var student = await _studentRepository.GetFirstAsync(student => student.Id == id);

        return new BaseResponseModel
        {
            Id = (await _studentRepository.DeleteAsync(student)).Id
        };
    }
}
