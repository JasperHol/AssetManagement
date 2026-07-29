using AssetManagement.Api.Controllers.Assets;
using AssetManagement.Application.Assets.CreateAsset;
using AssetManagement.Application.Assets.SearchAsset;
using AssetManagement.Application.Assets.SearchAssetStatus;
using AssetManagement.Application.Assets.UpdateAssetStatus;
using AssetManagement.Domain.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssetManagement.Api.Controllers.Assets;


[Route("api/Assets")]
[ApiController]
public class AssetsController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Assets.
    /// </summary>
    /// <remarks>
    /// Lijst van alle Assets ophalen.
    /// </remarks>
    [HttpGet("all_Assets")]
    public async Task<IActionResult> SearchAssets(CancellationToken cancellationToken)
    {
        var query = new SearchAssetQuery();

        var result = await sender.Send(query, cancellationToken);

        //return Ok(result.ToString());
        return Ok(result.Value);
    }

    /// <summary>
    /// Get All Assets with status.
    /// </summary>
    /// <remarks>
    /// Lijst van alle Assets ophalen met een gegeven status.
    /// </remarks>
    [HttpGet("AssetStatus/{id}")]
    public async Task<IActionResult> GetAssetStatus(
        AssetStatusId id,
        CancellationToken cancellationToken)
    {
        var command = new SearchAssetStatusQuery((int)id);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    /// <summary>
    /// Create New Asset.
    /// </summary>
    /// <remarks>
    /// Nieuwe Asset toevoegen.
    /// </remarks>
    [HttpPost("Asset_create")]
    public async Task<IActionResult> CreateAsset(
        CreateAssetRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAssetCommand(
            request.Name,
            request.Brand,
            request.Model,
            request.SerialNumber,
            request.MacAddress,
            request.ServiceTag,
            request.PurchaseDate,
            request.OrderNumber,
            request.CmdbLabel,
            request.DepreciationDate,
            request.MsLicenceMappingId,
            request.StatusId,
            request.AssetTypeId,
            request.PersonId,
            request.LocationId);


          
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(CreateAsset), new { id = result.Value }, result.Value);
    }


    /// <summary>
    /// Update AssetStatus.
    /// </summary>
    /// <remarks>
    /// Update Asset Status.
    /// </remarks>
    [HttpPut("Asset_updateStatus/{id:int}")]
    public async Task<IActionResult> UpdateAssetStatus(
        int id,
        [FromBody] UpdateAssetStatusRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateAssetStatusCommand(id, request.StatusId);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

}


