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
            new StartDate(request.StartDate),
            new EndDate(request.EndDate),
            new DataSource(request.DataSource),
            request.AgreementStatus,
            new AgreemnentSignDate(request.AgreemnentSignDate),
            new AgreementDeclineDate(request.AgreementDeclineDate),
            new AgreementDeclineReason(request.AgreementDeclineReason),
            request.AgreementUsageAgreementImage,
            request.AssetId,
            request.PersonId,
            request.PersonAssetUsageId,
            request.LocationId,
            request.AgreementStatusId

        );

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetUsage.Id);
    }
}