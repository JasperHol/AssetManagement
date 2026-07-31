namespace AssetManagement.Api.Controllers.Assets;

public sealed record CreateAssetRequest(
string Name,
string Brand,
string Model,
string SerialNumber,
string MacAddress,
string ServiceTag,
DateOnly PurchaseDate,
string OrderNumber,
string CmdbLabel,
DateOnly DepreciationDate,
int MsLicenceMappingId,
int AssetTypeId
);
