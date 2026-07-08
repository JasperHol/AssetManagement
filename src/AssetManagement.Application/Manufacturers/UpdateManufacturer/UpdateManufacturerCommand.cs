using AssetManagement.Application.Abstractions.Messaging;

namespace AssetManagement.Application.Manufacturers.UpdateManufacturer;

public record UpdateManufacturerCommand(int Id, bool Requestable)   : ICommand<int>;