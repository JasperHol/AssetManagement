namespace AssetManagement.Api.Controllers.Models;

public sealed record UpdateModelRequest(
    int Id,
    bool Requestable
    );