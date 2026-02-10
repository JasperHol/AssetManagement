using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Models.UpdateModel;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.UpdateModel;

internal sealed class UpdateModelCommandHandler
    : ICommandHandler<UpdateModelCommand, int>
{
    private readonly IModelRepository _modelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateModelCommandHandler(
        IModelRepository modelRepository,
        IUnitOfWork unitOfWork)
    {
        _modelRepository = modelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateModelCommand request,
    CancellationToken cancellationToken)
    {
        var model = await _modelRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (model is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Model.NotFound",
                    $"Model with id {request.Id} was not found"));
        }

        model.ToggleRequestable();

        // Optional: only needed if entity is detached
        //_modelRepository.Update(model);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(model.Id);
    }
}