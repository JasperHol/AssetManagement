
using AssetManagement.Application.AssetUsages.EndAssetUsage;
using AssetManagement.Application.AssetUsages.CreateAssetUsage;
using AssetManagement.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.AssetUsages;


[Route("api/AssetUsages")]
[ApiController]
public class AssetUsagesController(ISender sender) : ControllerBase
{
    ///// <summary>
    ///// Get All Assets.
    ///// </summary>
    ///// <remarks>
    ///// Lijst van alle Assets ophalen.
    ///// </remarks>
    //[HttpGet("all_assetusages")]
    //public async Task<IActionResult> SearchAssets(CancellationToken cancellationToken)
    //{
    //    var query = new SearchAssetQuery();

    //    var result = await sender.Send(query, cancellationToken);

    //    //return Ok(result.ToString());
    //    return Ok(result.Value);
    //}

    
    /// <summary>
    /// Create New AssetUsage.
    /// </summary>
    /// <remarks>
    /// Nieuwe AssetUsage toevoegen.
    /// </remarks>
    [HttpPost("AssetUsage_create")]
    public async Task<IActionResult> CreateAssetUsage(
        CreateAssetUsageRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAssetUsageCommand(
            request.AssetId,
            request.PersonId,
            request.LocationId,
            request.AgreementStatusId,
            request.StartDate,
            request.DataSource,
            request.PersonAssetUsageId);


          
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(CreateAssetUsage), new { id = result.Value }, result.Value);
    }


    /// <summary>
    /// End AssetUsage.
    /// </summary>
    /// <remarks>
    /// Ends the selecter AssetUsage.
    /// </remarks>
    [HttpPut("AssetUsages_end/{id:int}")]
    public async Task<IActionResult> UpdateAssetUsage(
        int id,
        CancellationToken cancellationToken)
    {
        var command = new EndAssetUsageCommand(id);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

}


