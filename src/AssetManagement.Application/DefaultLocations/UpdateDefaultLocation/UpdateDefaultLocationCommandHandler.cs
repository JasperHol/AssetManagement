using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.DefaultLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetManagement.Application.DefaultLocations.UpdateDefaultLocation;

internal sealed class UpdateDefaultLocationCommandHandler
    : ICommandHandler<UpdateDefaultLocationCommand, int>
{
    private readonly IDefaultLocationRepository _defaultLocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDefaultLocationCommandHandler(
        IDefaultLocationRepository defaultLocationRepository,
        IUnitOfWork unitOfWork)
    {
        _defaultLocationRepository = defaultLocationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateDefaultLocationCommand request,
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


        Description description = new(request.Description);
        defaultLocation.ChangeDescription(description);



        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(defaultLocation.Id);
    }
}