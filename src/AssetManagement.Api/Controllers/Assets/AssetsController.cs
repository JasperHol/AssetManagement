using AssetManagement.Api.Controllers.Assets;
using AssetManagement.Application.Assets.CreateAsset;
using AssetManagement.Application.Assets.SearchAsset;

using AssetManagement.Domain.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            request.AssetTypeId);


          
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(CreateAsset), new { id = result.Value }, result.Value);
    }
    

    ///// <summary>
    ///// Update Asset.
    ///// </summary>
    ///// <remarks>
    ///// Updates whether a Asset can be selected.
    ///// </remarks>
    //[HttpPut("Asset/{id:int}")]
    //public async Task<IActionResult> UpdateAsset(
    //    int id,
    //    [FromBody] UpdateAssetRequest request,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new UpdateAssetCommand(
    //        id,
    //        request.Requestable);

    //    var result = await sender.Send(command, cancellationToken);

    //    if (result.IsFailure)
    //    {
    //        return BadRequest(result.Error);
    //    }

    //    return NoContent();
    //}

}


