using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes;
using AssetManagement.Domain.Manufacturers;
using DomainRequestable = AssetManagement.Domain.AssetTypes.Requestable;

namespace AssetManagement.Application.AssetTypes.UpdateAssetType;

internal sealed class UpdateAssetTypeCommandHandler
    : ICommandHandler<UpdateAssetTypeCommand, int>
{
    private readonly IAssetTypeRepository _assetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetTypeCommandHandler(
        IAssetTypeRepository assetTypeRepository,
        IUnitOfWork unitOfWork)
    {
        _assetTypeRepository = assetTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateAssetTypeCommand request,
    CancellationToken cancellationToken)
    {
        var assetType = await _assetTypeRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (assetType is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "AssetType.NotFound",
                    $"AssetType with id {request.Id} was not found"));
        }

        //assetType.ToggleRequestable();

        DomainRequestable requestable = new(request.Requestable);
        assetType.ChangeRequestable(requestable);

        // Optional: only needed if entity is detached
        //_AssetTypeRepository.Update(AssetType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetType.Id);
    }
}