using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.AssetTypes;

public sealed record CreateAssetTypeRequest(
string Name,
string Description,
bool Requestable,
int DepreciationValue,
int DepreciationPeriod,
string DataSource,
int JiraId,
string PrefixName,
bool SecuritySensitive,
bool MobileEquipment,
int ModelId,
int AssetKindId
 );