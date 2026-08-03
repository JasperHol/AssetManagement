namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageLocationRequest(
int AssetId,
int LocationId
);
