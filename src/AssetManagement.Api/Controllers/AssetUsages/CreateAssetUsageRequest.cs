namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageRequest(
int PreviousAssetUsageId,
int PersonId,
int LocationId,
int StatusId
);
