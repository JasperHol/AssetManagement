using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.StatusTransitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsage;

internal sealed class CreateAssetUsageCommandHandler
    : ICommandHandler<CreateAssetUsageCommand, int>
{
    private readonly IAssetUsageRepository _assetUsageRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IStatusTransitionRepository _statusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetUsageCommandHandler(
        IAssetUsageRepository AssetUsageRepository,
        IAssetRepository AssetRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = AssetUsageRepository;
        _assetRepository = AssetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetUsageCommand request, CancellationToken cancellationToken)
    {


        var previousAssetUsage = await _assetUsageRepository
            .GetByIdAsync(request.PreviousAssetUsageId, cancellationToken);

        if (previousAssetUsage is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "PreviousAssetUsage.NotFound",
                    $"PreviousAssetUsage with id {request.PreviousAssetUsageId} was not found"));
        }

        var asset = await _assetRepository.GetByIdAsync(
            previousAssetUsage.AssetId,
            cancellationToken);

                if (asset is null)
                {
                    return Result.Failure<int>(
                        Error.NotFound(
                            "Asset.NotFound",
                            $"Asset with id {previousAssetUsage.AssetId} was not found"));
                }

        var allowed = await _statusTransitionRepository.IsTransitionAllowedAsync(
            asset.StatusId,
            request.StatusId,
            cancellationToken);

        if (!allowed)
        {
            return Result.Failure<int>(
                Error.Validation(
                    "StatusTransition.NotAllowed",
                    $"Status transition from {asset.StatusId} to {request.StatusId} is not allowed."));
        }

        asset.UpdateStatus(request.StatusId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);



        previousAssetUsage.End();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var personId = request.PersonId == 0 ? (int?)null : request.PersonId;
        var locationId = request.LocationId == 0 ? (int?)null : request.LocationId;

        var assetUsage = AssetManagement.Domain.AssetUsages.AssetUsage.Create(
            previousAssetUsage.AssetId,
            personId,
            locationId,
            1, null, null, null, null, null, null,null);

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);





        asset.UpdateStatus(request.StatusId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetUsage.Id);
    }
}