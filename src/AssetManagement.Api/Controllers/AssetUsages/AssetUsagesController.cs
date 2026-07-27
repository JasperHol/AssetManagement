using AssetManagement.Api.Controllers.AssetUsages;
using AssetManagement.Application.AssetUsages.CreateAssetUsage;
using AssetManagement.Application.AssetUsages.SearchAssetUsage;


using AssetManagement.Domain.AssetUsages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.AssetUsages;


[Route("api/AssetUsages")]
[ApiController]
public class AssetUsagesController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All AssetUsages.
    /// </summary>
    /// <remarks>
    /// Lijst van alle AssetUsages ophalen.
    /// </remarks>
    [HttpGet("all_AssetUsages")]
    public async Task<IActionResult> SearchAssetUsages(CancellationToken cancellationToken)
    {
        var query = new SearchAssetUsageQuery();

        var result = await sender.Send(query, cancellationToken);

        //return Ok(result.ToString());
        return Ok(result.Value);
    }

    
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
            request.EndDate,
            request.DataSource,
            request.AgreementSignDate,
            request.AgreementDeclineDate,
            request.AgreementDeclineReason,
            request.AgreementUsageAgreementImage);


          
        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(CreateAssetUsage), new { id = result.Value }, result.Value);
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


