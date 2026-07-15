using AssetManagement.Application.Abstractions.Messaging;

using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.CreateAsset;

internal sealed class CreateAssetCommandHandler(
    IAssetRepository AssetRepository,
    IUnitOfWork unitOfWork)
        : ICommandHandler<CreateAssetCommand, int>
{
    private readonly IAssetRepository _AssetRepository = AssetRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        //var asset = Asset.Create(
        //    new Name(request.Name),
        //    new Brand(request.Brand),
        //    new Model(request.Model),
        //    new SerialNumber(request.SerialNumber),
        //    new MacAddress(request.MacAddress),
        //    new ServiceTag(request.ServiceTag),
        //    new PurchaseDate(request.PurchaseDate),
        //    new OrderNumber(request.OrderNumber),
        //    new LostDate(request.LostDate),
        //    new DisposedDate(request.DisposedDate),
        //    new CmdbLabel(request.CmdbLabel),
        //    new DepreciationDate(request.DepreciationDate),
        //    request.msLicenceMappingId,
        //    request.statusId,
        //    request.assetTypeId);
        //var asset = Asset.Create(
        //    new Name(request.Name),
        //    new Brand(request.Brand),
        //    new Model(request.Model),
        //    new SerialNumber(request.SerialNumber),
        //    new MacAddress(request.MacAddress),
        //    new ServiceTag(request.ServiceTag),
        //    new PurchaseDate(request.PurchaseDate),
        //    new OrderNumber(request.OrderNumber),
        //    new LostDate(DateTime.MinValue),
        //    new DisposedDate(DateTime.MinValue),
        //    new CmdbLabel(request.CmdbLabel),
        //    new DepreciationDate(request.DepreciationDate),
        //    0,0,0);

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

        _AssetRepository.Add(asset);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(asset.Id);
    }
}