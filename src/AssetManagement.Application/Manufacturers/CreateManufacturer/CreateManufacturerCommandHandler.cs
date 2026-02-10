using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Manufacturers.CreateManufacturer;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.CreateManufacturer;

internal sealed class CreateManufacturerCommandHandler
    : ICommandHandler<CreateManufacturerCommand, int>
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateManufacturerCommandHandler(
        IManufacturerRepository manufacturerRepository,
        IUnitOfWork unitOfWork)
    {
        _manufacturerRepository = manufacturerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.Create(
            new Name(request.Name),
            new Description(request.Description)
        // Requestable defaults to true
        );

        _manufacturerRepository.Add(manufacturer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(manufacturer.Id.Value);
    }
}
