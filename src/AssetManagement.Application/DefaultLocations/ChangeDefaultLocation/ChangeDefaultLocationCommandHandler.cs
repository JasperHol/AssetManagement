using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.DefaultLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetManagement.Application.DefaultLocations.ChangeDefaultLocation;

internal sealed class ChangeDefaultLocationCommandHandler
    : ICommandHandler<ChangeDefaultLocationCommand, int>
{
    private readonly IDefaultLocationRepository _defaultLocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeDefaultLocationCommandHandler(
        IDefaultLocationRepository defaultLocationRepository,
        IUnitOfWork unitOfWork)
    {
        _defaultLocationRepository = defaultLocationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    ChangeDefaultLocationCommand request,
    CancellationToken cancellationToken)
    {
        var defaultLocation = await _defaultLocationRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (defaultLocation is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "DefaultLocation.NotFound",
                    $"DefaultLocation with id {request.Id} was not found"));
        }

        //bool exists = await _defaultLocationRepository.ExistsAsync(
        //    request.Id,
        //    request.LocationId,
        //    cancellationToken);

        //if (exists)
        //{
        //    return Result.Failure<int>(
        //        Error.Validation(
        //            "DefaultLocation.AlreadyExists",
        //            $"A DefaultLocation with StatusId {request.Id} and LocationId {request.LocationId} already exists."));
        //}

        bool StatusIdexists = await _defaultLocationRepository.StatusIdExistsAsync(
            request.Id,
            cancellationToken);

        if (StatusIdexists)
        {
            return Result.Failure<int>(
                Error.Validation(
                    "DefaultLocation.AlreadyExists",
                    $"A DefaultLocation with StatusId {request.Id} already exists."));
        }

        bool LocationIdexists = await _defaultLocationRepository.LocationIdExistsAsync(
            request.LocationId,
            cancellationToken);

        if (LocationIdexists)
        {
            return Result.Failure<int>(
                Error.Validation(
                    "DefaultLocation.AlreadyExists",
                    $"A DefaultLocation with LocationId {request.LocationId} already exists."));
        }


        defaultLocation.ChangeDefaultLocation(request.LocationId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(defaultLocation.Id);
    }
}