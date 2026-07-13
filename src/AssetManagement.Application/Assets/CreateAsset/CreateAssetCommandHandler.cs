using AssetManagement.Application.Abstractions.Messaging;

using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.CreateAsset;

internal sealed class CreateAssetCommandHandler
    : ICommandHandler<CreateAssetCommand, int>
{
    private readonly IAssetRepository _AssetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCommandHandler(
        IAssetRepository AssetRepository,
        IUnitOfWork unitOfWork)
    {
        _AssetRepository = AssetRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = Asset.Create(
            new Name(request.Name)
       
        );

        _AssetRepository.Add(asset);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(asset.Id);
    }
}