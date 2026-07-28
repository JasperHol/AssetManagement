using AssetManagement.Application.Abstractions.Messaging;

namespace AssetManagement.Application.AssetUsages.SignAssetUsage;

public record SignAssetUsageCommand(int Id )   : ICommand<int>;