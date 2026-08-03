using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AssetUsages.CreateAssetUsagePerson;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.StatusTransitions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsagePersons.CreateAssetUsagePerson;

internal sealed class CreateAssetUsagePersonCommandHandler
    : ICommandHandler<CreateAssetUsagePersonCommand, int>
{
    private readonly IAssetUsageRepository _assetUsageRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IStatusTransitionRepository _statusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetUsagePersonCommandHandler(
        IAssetUsageRepository AssetUsagePersonRepository,
        IAssetRepository AssetRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = AssetUsagePersonRepository;
        _assetRepository = AssetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetUsagePersonCommand request, CancellationToken cancellationToken)
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
            request.PersonId,
            null,
            1, null, null, null, null, null, null, null);

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return Result.Success(openAssetUsage.Id);
    }
}