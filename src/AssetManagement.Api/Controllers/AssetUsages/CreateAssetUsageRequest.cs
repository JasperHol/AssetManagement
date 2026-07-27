namespace AssetManagement.Api.Controllers.AssetUsages;

public sealed record CreateAssetUsageRequest(
int AssetId,
int PersonId,
int LocationId,
int AgreementStatusId,
DateTime StartDate,
DateTime EndDate,
string DataSource,
DateTime AgreementSignDate,
DateTime AgreementDeclineDate,
string AgreementDeclineReason,
string AgreementUsageAgreementImage);
