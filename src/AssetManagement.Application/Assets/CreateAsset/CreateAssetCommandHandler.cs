using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.DefaultLocations.SearchDefaultLocationFromStatus;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.DefaultLocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.CreateAsset;

internal sealed class CreateAssetCommandHandler(
    IAssetRepository assetRepository,
    IAssetUsageRepository assetUsageRepository,
    IDefaultLocationRepository defaultLocationRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAssetCommand, int>
{
    private readonly IAssetRepository _assetRepository = assetRepository;
    private readonly IAssetUsageRepository _assetUsageRepository = assetUsageRepository;
    private readonly IDefaultLocationRepository _defaultLocationRepository = defaultLocationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        

        var asset = Asset.Create(
        new Name(request.Name),
        new Brand(request.Brand),
        new Model(request.Model),
        new SerialNumber(request.SerialNumber),
        new MacAddress(request.MacAddress),
        new ServiceTag(request.ServiceTag),
        new PurchaseDate(request.PurchaseDate),
        new OrderNumber(request.OrderNumber),
        new LostDate(DateTime.MinValue),
        new DisposedDate(DateTime.MinValue),
        new CmdbLabel(request.CmdbLabel),
        new DepreciationDate(request.DepreciationDate),
        request.MsLicenceMappingId,
        request.StatusId,
        request.AssetTypeId);

        _assetRepository.Add(asset);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //var personId = request.PersonId == 0 ? (int?)null : request.PersonId;
        //var locationId = request.LocationId == 0 ? (int?)null : request.LocationId;
        int? personId = null;


        var defaultLocation = await _defaultLocationRepository.GetByStatusIdAsync(2,cancellationToken);

        if (defaultLocation is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "DefaultLocation.NotFound",
                    "No default location found for status 2."));
        }

        var locationId = defaultLocation.LocationId;

        var assetUsage = AssetUsage.Create(
            asset.Id,
            personId,
            locationId,
            1, // agreementStatusId altijd 1=wacht op tekenen);
            new StartDate(DateTime.UtcNow),
            new EndDate(null),
            new DataSource("API"),
            new AgreementSignDate(null),
            new AgreementDeclineDate(null),
            new AgreementDeclineReason(string.Empty),
            string.Empty
            ); 

        _assetUsageRepository.Add(assetUsage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(asset.Id);
    }
}