using N_Tier.Application.Models.Specialist;
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

public class SpecialistService : ISpecialistService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly ISpecialistRepository _specialistRepository;

    public SpecialistService(ISpecialistRepository specialistRepository, IMapper mapper, IClaimService claimService)
    {
        _specialistRepository = specialistRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<SpecialistResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var specialists = await _specialistRepository.GetAllAsync(specialist => specialist.Id == specialist.Id);

        return _mapper.Map<IEnumerable<SpecialistResponseModel>>(specialists);
    }

    public async Task<CreateSpecialistResponseModel> CreateAsync(CreateSpecialistModel createSpecialistModel)
    {
        var specialist = _mapper.Map<Specialist>(createSpecialistModel);

        var addedSpecialist = await _specialistRepository.AddAsync(specialist);

        return new CreateSpecialistResponseModel
        {
            Id = addedSpecialist.Id
        };
    }

    public async Task<UpdateSpecialistResponseModel> UpdateAsync(Guid id, UpdateSpecialistModel updateSpecialistModel)
    {
        var specialist = await _specialistRepository.GetFirstAsync(specialist => specialist.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != specialist.CreatedBy)
        //    throw new BadRequestException("The selected specialist does not belong to you");

        specialist.Name = updateSpecialistModel.Name;

        return new UpdateSpecialistResponseModel
        {
            Id = (await _specialistRepository.UpdateAsync(specialist)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var specialist = await _specialistRepository.GetFirstAsync(specialist => specialist.Id == id);

        return new BaseResponseModel
        {
            Id = (await _specialistRepository.DeleteAsync(specialist)).Id
        };
    }
}
