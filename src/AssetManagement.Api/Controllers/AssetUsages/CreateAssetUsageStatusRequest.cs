namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageStatusRequest(
int AssetId,
int StatusId
);
