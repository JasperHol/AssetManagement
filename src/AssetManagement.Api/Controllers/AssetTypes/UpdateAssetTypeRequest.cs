using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.AssetTypes;

public sealed record UpdateAssetTypeRequest(
    int Id,
    bool Requestable
    );