using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AssetTypes.CreateAssetType;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.CreateAssetType;

internal sealed class CreateAssetTypeCommandHandler
    : ICommandHandler<CreateAssetTypeCommand, int>
{
    private readonly IAssetTypeRepository _AssetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetTypeCommandHandler(
        IAssetTypeRepository AssetTypeRepository,
        IUnitOfWork unitOfWork)
    {
        _AssetTypeRepository = AssetTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetTypeCommand request, CancellationToken cancellationToken)
    {
        var assetType = AssetType.Create(
            new Name(request.Name),
            new Description(request.Description),
            new Requestable(request.Requestable),
            new DepreciationValue(request.DepreciationValue),
            new DepreciationPeriod(request.DepreciationPeriod),
            new DataSource(request.DataSource),
            new JiraId(request.JiraId),
            new PrefixName(request.PrefixName),
            new SecuritySensitive(request.SecuritySensitive),
            new MobileEquipment(request.MobileEquipment),
            request.ModelId,
            request.AssetKindId


        // Requestable defaults to true
        );

        _AssetTypeRepository.Add(assetType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetType.Id);

    }
}



