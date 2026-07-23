namespace AssetManagement.Api.Controllers.Locations;

public sealed record CreateLocationRequest(
    int BuildingId,
    int PersonId,
    int ReportingUnitId,
    string Name,
    string Remark,
    bool Requestable
);