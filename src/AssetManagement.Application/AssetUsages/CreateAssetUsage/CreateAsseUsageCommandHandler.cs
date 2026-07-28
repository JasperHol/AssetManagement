using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
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
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetUsageCommandHandler(
        IAssetUsageRepository AssetUsageRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = AssetUsageRepository;
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

        previousAssetUsage.End();

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        var assetUsage = AssetUsage.Create(
            request.AssetId,
            request.PersonId,
            request.LocationId,
            1, null, null, null, null, null, null,null);

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetUsage.Id);
    }
}