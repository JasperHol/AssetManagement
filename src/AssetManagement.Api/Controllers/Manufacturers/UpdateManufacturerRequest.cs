using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Manufacturers;

public sealed record UpdateManufacturerRequest(int Id,bool Requestable);