using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetUsages;


namespace AssetManagement.Application.AssetUsages.EndAssetUsage;

internal sealed class EndAssetUsageCommandHandler
    : ICommandHandler<EndAssetUsageCommand, int>
{
    private readonly IAssetUsageRepository _assetUsageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EndAssetUsageCommandHandler(
        IAssetUsageRepository assetUsageRepository,
        IUnitOfWork unitOfWork)
    {
        _assetUsageRepository = assetUsageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    EndAssetUsageCommand request,
    CancellationToken cancellationToken)
    {
        var assetUsage = await _assetUsageRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (assetUsage is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "AssetUsage.NotFound",
                    $"AssetUsage with id {request.Id} was not found"));
        }




        assetUsage.End();

        

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetUsage.Id);
    }
}