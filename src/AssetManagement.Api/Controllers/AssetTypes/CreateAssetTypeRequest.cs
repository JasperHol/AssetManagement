using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.AssetTypes;

public sealed record CreateAssetTypeRequest(
string Name,
string Description
);