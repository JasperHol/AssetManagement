using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Assets.UpdateAssetStatus;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetManagement.Application.AssetStatus.UpdateAssetStatus;

internal sealed class UpdateAssetStatusCommandHandler
    : ICommandHandler<UpdateAssetStatusCommand, int>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetStatusCommandHandler(
        IAssetRepository assetRepository,
        IUnitOfWork unitOfWork)
    {
        _assetRepository = assetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateAssetStatusCommand request,
    CancellationToken cancellationToken)
    {
        var asset = await _assetRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (asset is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Asset.NotFound",
                    $"Asset with id {request.Id} was not found"));
        }

        asset.UpdateStatus(request.StatusId);


        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(asset.Id);
    }
}