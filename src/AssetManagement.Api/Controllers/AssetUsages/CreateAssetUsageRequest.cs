namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageRequest(
int PreviousAssetUsageId,
int AssetId,
int PersonId,
int LocationId
);
