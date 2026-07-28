using AssetManagement.Application.Abstractions.Messaging;

namespace AssetManagement.Application.AssetUsages.DeclineAssetUsage;

public record DeclineAssetUsageCommand(int Id, string AgreementDeclineReason)   : ICommand<int>;