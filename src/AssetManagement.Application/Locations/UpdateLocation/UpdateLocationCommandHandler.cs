using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Locations.UpdateLocation;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRequestable = AssetManagement.Domain.Locations.Requestable;

namespace AssetManagement.Application.Locations.UpdateLocation;

internal sealed class UpdateLocationCommandHandler
    : ICommandHandler<UpdateLocationCommand, int>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(
        ILocationRepository locationRepository,
        IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateLocationCommand request,
    CancellationToken cancellationToken)
    {
        var location = await _locationRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (location is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Location.NotFound",
                    $"Location with id {request.Id} was not found"));
        }

        //location.ToggleRequestable();
        DomainRequestable requestable = new(request.Requestable);
        location.ChangeRequestable(requestable);

        // Optional: only needed if entity is detached
        //_locationRepository.Update(location);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(location.Id);
    }
}