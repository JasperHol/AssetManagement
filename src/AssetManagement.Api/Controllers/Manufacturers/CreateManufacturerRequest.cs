using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Manufacturers;

public sealed record CreateManufacturerRequest(
string Name,
string Description
);