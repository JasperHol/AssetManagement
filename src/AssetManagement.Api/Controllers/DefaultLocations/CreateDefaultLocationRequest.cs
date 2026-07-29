namespace AssetManagement.Api.Controllers.DefaultLocations;

public sealed record CreateDefaultLocationRequest(
    int StatusId,
    int LocationId,
    string Description
);