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
            new Description(request.Description)
        // Requestable defaults to true
        );

        _AssetTypeRepository.Add(assetType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetType.Id);

    }
}



