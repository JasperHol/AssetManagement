using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.DefaultLocations.CreateDefaultLocation;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.DefaultLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.CreateDefaultLocation;

internal sealed class CreateDefaultLocationCommandHandler
    : ICommandHandler<CreateDefaultLocationCommand, int>
{
    private readonly IDefaultLocationRepository _defaultLocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDefaultLocationCommandHandler(
        IDefaultLocationRepository defaultLocationRepository,
        IUnitOfWork unitOfWork)
    {
        _defaultLocationRepository = defaultLocationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateDefaultLocationCommand request, CancellationToken cancellationToken)
    {

        bool StatusIdexists = await _defaultLocationRepository.StatusIdExistsAsync(
            request.StatusId,
            cancellationToken);

        if (StatusIdexists)
        {
            return Result.Failure<int>(
                Error.Validation(
                    "DefaultLocation.AlreadyExists",
                    $"A DefaultLocation with StatusId {request.StatusId} already exists."));
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
        var defaultLocation = DefaultLocation.Create(
            request.StatusId,
            request.LocationId,
            new Description(request.Description));

        _defaultLocationRepository.Add(defaultLocation);

 
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(defaultLocation.Id);
    }
}