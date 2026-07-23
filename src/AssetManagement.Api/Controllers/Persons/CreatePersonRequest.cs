namespace AssetManagement.Api.Controllers.Persons;

public sealed record CreatePersonRequest(
    string Name,
    bool Requestable,
    string EmailAddress,
    string EmloyeeNumber,
    string DataSource,
    string Sid,
    string AccountName,
    int WorksForId);





