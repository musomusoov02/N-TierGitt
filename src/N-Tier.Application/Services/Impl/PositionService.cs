using N_Tier.Application.Models.Position;
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

public class PositionService : IPositionService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public PositionService(IPositionRepository positionRepository, IMapper mapper, IClaimService claimService)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<PositionResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var positions = await _positionRepository.GetAllAsync(position => position.Id == position.Id);

        return _mapper.Map<IEnumerable<PositionResponseModel>>(positions);
    }

    public async Task<CreatePositionResponseModel> CreateAsync(CreatePositionModel createPositionModel)
    {
        var position = _mapper.Map<Position>(createPositionModel);

        var addedPosition = await _positionRepository.AddAsync(position);

        return new CreatePositionResponseModel
        {
            Id = addedPosition.Id
        };
    }

    public async Task<UpdatePositionResponseModel> UpdateAsync(Guid id, UpdatePositionModel updatePositionModel)
    {
        var position = await _positionRepository.GetFirstAsync(position => position.Id == id);

        //var userId = _claimService.GetUserId();

        //if (userId != position.CreatedBy)
        //    throw new BadRequestException("The selected position does not belong to you");

        position.Name = updatePositionModel.Name;

        return new UpdatePositionResponseModel
        {
            Id = (await _positionRepository.UpdateAsync(position)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var position = await _positionRepository.GetFirstAsync(position => position.Id == id);

        return new BaseResponseModel
        {
            Id = (await _positionRepository.DeleteAsync(position)).Id
        };
    }
}
