using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AssetTypes.UpdateAssetType;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.UpdateAssetType;

internal sealed class UpdateAssetTypeCommandHandler
    : ICommandHandler<UpdateAssetTypeCommand, int>
{
    private readonly IAssetTypeRepository _AssetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetTypeCommandHandler(
        IAssetTypeRepository AssetTypeRepository,
        IUnitOfWork unitOfWork)
    {
        _AssetTypeRepository = AssetTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateAssetTypeCommand request,
    CancellationToken cancellationToken)
    {
        var AssetType = await _AssetTypeRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (AssetType is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "AssetType.NotFound",
                    $"AssetType with id {request.Id} was not found"));
        }

        AssetType.ToggleRequestable();

        // Optional: only needed if entity is detached
        //_AssetTypeRepository.Update(AssetType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(AssetType.Id);
    }
}