using AssetManagement.Domain.AssetUsages;

namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record DeclineAssetUsageRequest(string AgreementDeclineReason);
