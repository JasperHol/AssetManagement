using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AssetUsage.CreateAssetUsageStatus;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.DefaultLocations;
using AssetManagement.Domain.StatusTransitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsageStatuss.CreateAssetUsageStatus;

internal sealed class CreateAssetUsageStatusCommandHandler
    : ICommandHandler<CreateAssetUsageStatusCommand, int>
{
    private readonly IAssetUsageRepository _assetUsageRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IStatusTransitionRepository _statusTransitionRepository;
    private readonly IDefaultLocationRepository _defaultLocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetUsageStatusCommandHandler(
        IAssetUsageRepository assetUsageRepository,
        IAssetRepository assetRepository,
        IStatusTransitionRepository statusTransitionRepository,
        IDefaultLocationRepository defaultLocationRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = assetUsageRepository;
        _assetRepository = assetRepository;
        _statusTransitionRepository = statusTransitionRepository;
        _defaultLocationRepository = defaultLocationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetUsageStatusCommand request, CancellationToken cancellationToken)
    {


        var asset = await _assetRepository.GetByIdAsync(
            request.AssetId,
            cancellationToken);

        if (asset is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Asset.NotFound",
                    $"Asset with id {request.AssetId} was not found"));
        }



        var openAssetUsage = await _assetUsageRepository.GetOpenByAssetIdAsync(
            request.AssetId,
            cancellationToken);

        if (openAssetUsage is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "AssetUsage.NotFound",
                    $"No open AssetUsage found for asset with id {request.AssetId}."));
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


        var defaultLocation = await _defaultLocationRepository.GetByStatusIdAsync(
            request.StatusId,
            cancellationToken);

        if (defaultLocation is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "DefaultLocation.NotFound",
                    $"No default location configured for status {request.StatusId}."));
        }





        asset.UpdateStatus(request.StatusId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        openAssetUsage.End(); //dit moet na de status check

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        var assetUsage = AssetManagement.Domain.AssetUsages.AssetUsage.Create(
              openAssetUsage.AssetId,
              null, 
              defaultLocation.LocationId, // de defaultLocation behorende bij de gekozen status 
              1, null, null, null, null, null, null, null);

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(asset.Id);
    }
}