namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageRequest(
        int AssetId,
        int PersonId,
        int LocationId,
        int AgreementStatusId,
        DateTime StartDate,
        string DataSource,
        int PersonAssetUsageId

);




