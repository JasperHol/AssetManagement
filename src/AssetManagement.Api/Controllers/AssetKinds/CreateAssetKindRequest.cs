namespace AssetManagement.Api.Controllers.AssetKinds;

public sealed record CreateAssetKindRequest(
string Name,
bool HasMacAddress,
bool IsPhysical);





