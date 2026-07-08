using AssetManagement.Application.Abstractions.Messaging;

namespace AssetManagement.Application.AssetTypes.UpdateAssetType;

public record UpdateAssetTypeCommand(int Id, bool Requestable)   : ICommand<int>;