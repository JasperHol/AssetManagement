using AssetManagement.Application.Abstractions.Messaging;

namespace AssetManagement.Application.AssetUsages.EndAssetUsage;

public record EndAssetUsageCommand(int Id, DateTime EndDate)   : ICommand<int>;