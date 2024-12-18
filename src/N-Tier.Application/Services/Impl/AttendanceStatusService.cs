using N_Tier.Application.Models.AttendanceStatus;
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

public class AttendanceStatusService : IAttendanceStatusService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IAttendanceStatusRepository _attendanceStatusRepository;

    public AttendanceStatusService(IAttendanceStatusRepository attendanceStatusRepository, IMapper mapper, IClaimService claimService)
    {
        _attendanceStatusRepository = attendanceStatusRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<AttendanceStatusResponseModel>> GetAllAsync()
    {
        //var currentUserId = _claimService.GetUserId();

        var attendanceStatuses = await _attendanceStatusRepository.GetAllAsync(status => status.Id == status.Id);

        return _mapper.Map<IEnumerable<AttendanceStatusResponseModel>>(attendanceStatuses);
    }

    public async Task<CreateAttendanceStatusResponseModel> CreateAsync(CreateAttendanceStatusModel createAttendanceStatusModel)
    {
        var attendanceStatus = _mapper.Map<AttendanceStatus>(createAttendanceStatusModel);

        var addedAttendanceStatus = await _attendanceStatusRepository.AddAsync(attendanceStatus);

        return new CreateAttendanceStatusResponseModel
        {
            Id = addedAttendanceStatus.Id
        };
    }

    public async Task<UpdateAttendanceStatusResponseModel> UpdateAsync(Guid id, UpdateAttendanceStatusModel updateAttendanceStatusModel)
    {
        var attendanceStatus = await _attendanceStatusRepository.GetFirstAsync(status => status.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != attendanceStatus.CreatedBy)
        //    throw new BadRequestException("The selected attendance status does not belong to you");

        attendanceStatus.Name = updateAttendanceStatusModel.Name;

        return new UpdateAttendanceStatusResponseModel
        {
            Id = (await _attendanceStatusRepository.UpdateAsync(attendanceStatus)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var attendanceStatus = await _attendanceStatusRepository.GetFirstAsync(status => status.Id == id);

        return new BaseResponseModel
        {
            Id = (await _attendanceStatusRepository.DeleteAsync(attendanceStatus)).Id
        };
    }
}
