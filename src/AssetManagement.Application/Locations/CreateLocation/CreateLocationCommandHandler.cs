using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Locations.CreateLocation;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.CreateLocation;

internal sealed class CreateLocationCommandHandler
    : ICommandHandler<CreateLocationCommand, int>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(
        ILocationRepository locationRepository,
        IUnitOfWork unitOfWork)
    {
        _locationRepository = locationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = Location.Create(
            request.BuildingId,
            request.PersonId,
            request.ReportingUnitId,
            new Name(request.Name),
            new Remark(request.Remark),
            new Requestable(request.Requestable));

        _locationRepository.Add(location);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(location.Id);
    }
}