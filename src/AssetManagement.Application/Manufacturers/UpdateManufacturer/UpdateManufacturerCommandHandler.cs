using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.UpdateManufacturer;

internal sealed class UpdateManufacturerCommandHandler
    : ICommandHandler<UpdateManufacturerCommand, int>
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateManufacturerCommandHandler(
        IManufacturerRepository manufacturerRepository,
        IUnitOfWork unitOfWork)
    {
        _manufacturerRepository = manufacturerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdateManufacturerCommand request,
    CancellationToken cancellationToken)
    {
        var manufacturer = await _manufacturerRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (manufacturer is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Manufacturer.NotFound",
                    $"Manufacturer with id {request.Id} was not found"));
        }

        manufacturer.ToggleRequestable();

        // Optional: only needed if entity is detached
        //_manufacturerRepository.Update(manufacturer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(manufacturer.Id.Value);
    }
}