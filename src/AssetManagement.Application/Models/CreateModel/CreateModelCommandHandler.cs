using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Models.CreateModel;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.CreateModel;

internal sealed class CreateAssetKindCommandHandler
    : ICommandHandler<CreateModelCommand, int>
{
    private readonly IModelRepository _modelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetKindCommandHandler(
        IModelRepository modelRepository,
        IUnitOfWork unitOfWork)
    {
        _modelRepository = modelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var model = Model.Create(
            new Name(request.Name),
            new Description(request.Description),
            new ManufacturerId(request.ManufacturerId)
        // Requestable defaults to true
        );

        _modelRepository.Add(model);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(model.Id.Value);
    }
}