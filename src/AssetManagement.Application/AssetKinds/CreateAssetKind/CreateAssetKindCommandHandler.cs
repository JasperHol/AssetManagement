using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetKinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.CreateAssetKind;

internal sealed class CreateAssetKindCommandHandler
    : ICommandHandler<CreateAssetKindCommand, int>
{
    private readonly IAssetKindRepository _AssetKindRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetKindCommandHandler(
        IAssetKindRepository AssetKindRepository,
        IUnitOfWork unitOfWork)
    {
        _AssetKindRepository = AssetKindRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetKindCommand request, CancellationToken cancellationToken)
    {
        var assetKind = AssetKind.Create(
            new Name(request.Name),
            new HasMacAddress(request.HasMacAddress),
            new IsPhysical(request.IsPhysical)
       
        );

        _AssetKindRepository.Add(assetKind);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(assetKind.Id);
    }
}