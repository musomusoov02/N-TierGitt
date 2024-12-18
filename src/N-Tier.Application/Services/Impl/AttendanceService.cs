using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Attendance;
using AutoMapper;
using N_Tier.Application.Exceptions;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl;

public class AttendanceService : IAttendanceService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper, IClaimService claimService)
    {
        _attendanceRepository = attendanceRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<AttendanceResponseModel>> GetAllAsync()
    {
        //var currentUserId = _claimService.GetUserId();

        var attendances = await _attendanceRepository.GetAllAsync(tl => tl.Id==tl.Id);

        return _mapper.Map<IEnumerable<AttendanceResponseModel>>(attendances);
    }

    public async Task<CreateAttendanceResponseModel> CreateAsync(CreateAttendanceModel createAttendanceModel)
    {
        var attendance = _mapper.Map<Attendance>(createAttendanceModel);

        var addedAttendance = await _attendanceRepository.AddAsync(attendance);

        return new CreateAttendanceResponseModel
        {
            Id = addedAttendance.Id
        };
    }

    public async Task<UpdateAttendanceResponseModel> UpdateAsync(Guid id, UpdateAttendanceModel updateAttendanceModel)
    {
        var attendance = await _attendanceRepository.GetFirstAsync(tl => tl.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != attendance.CreatedBy)
        //    throw new BadRequestException("The selected list does not belong to you");

        attendance.AttendanceStatusId = updateAttendanceModel.AttendanceStatusId;
        attendance.StudentId = updateAttendanceModel.StudentId;
        attendance.Data = updateAttendanceModel.Data;

        return new UpdateAttendanceResponseModel
        {
            Id = (await _attendanceRepository.UpdateAsync(attendance)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var attendance = await _attendanceRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _attendanceRepository.DeleteAsync(attendance)).Id
        };
    }
}
