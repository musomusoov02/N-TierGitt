using N_Tier.Application.Models.Employee;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Employee;
using AutoMapper;
using N_Tier.Application.Exceptions;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IClaimService claimService)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var employees = await _employeeRepository.GetAllAsync(e => e.Id == e.Id);

        return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
    }

    public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        var employee = _mapper.Map<Employee>(createEmployeeModel);

        var addedEmployee = await _employeeRepository.AddAsync(employee);

        return new CreateEmployeeResponseModel
        {
            Id = addedEmployee.Id
        };
    }

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != employee.CreatedBy)
        //    throw new BadRequestException("The selected employee does not belong to you");

        employee.Person = updateEmployeeModel.Person;
        employee.PositionId = updateEmployeeModel.PositionId;
        employee.Salary = updateEmployeeModel.Salary;

        return new UpdateEmployeeResponseModel
        {
            Id = (await _employeeRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var employee = await _employeeRepository.GetFirstAsync(e => e.Id == id);

        return new BaseResponseModel
        {
            Id = (await _employeeRepository.DeleteAsync(employee)).Id
        };
    }
}
