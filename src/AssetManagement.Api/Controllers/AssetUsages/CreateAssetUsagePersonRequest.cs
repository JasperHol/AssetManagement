namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsagePersonRequest(
int AssetId,
int PersonId
);
