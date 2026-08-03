using AssetManagement.Application.AssetUsages.CreateAssetUsageLocation;
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

namespace AssetManagement.Application.AssetUsageLocations.CreateAssetUsageLocation;

internal sealed class CreateAssetUsageLocationCommandHandler
    : ICommandHandler<CreateAssetUsageLocationCommand, int>
{
    private readonly IAssetUsageRepository _assetUsageRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IStatusTransitionRepository _statusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetUsageLocationCommandHandler(
        IAssetUsageRepository AssetUsageLocationRepository,
        IAssetRepository AssetRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = AssetUsageLocationRepository;
        _assetRepository = AssetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetUsageLocationCommand request, CancellationToken cancellationToken)
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


        openAssetUsage.End();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

    

        var assetUsage = AssetManagement.Domain.AssetUsages.AssetUsage.Create(
            openAssetUsage.AssetId,
            null, 
            request.LocationId,
            1, null, null, null, null, null, null, null);

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return Result.Success(openAssetUsage.Id);
    }
}