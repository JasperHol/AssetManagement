using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
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
        var assetUsage = AssetUsage.Create(
            request.AssetId,
            request.PersonId,
            request.LocationId,
            request.AgreementStatusId,
            new StartDate(DateTime.UtcNow),
            null,                   // always empty on create
            new DataSource(request.DataSource),
            null,                   // always empty on create
            null,                   // always empty on create
            null,                   // always empty on create
            null,                   // always empty on create
            request.PersonAssetUsageId

        );

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetUsage.Id);
    }
}