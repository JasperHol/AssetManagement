namespace AssetManagement.Api.Controllers.Models;

public sealed record CreateModelRequest(
    string Name,
    string Description,
    int ManufacturerId
);