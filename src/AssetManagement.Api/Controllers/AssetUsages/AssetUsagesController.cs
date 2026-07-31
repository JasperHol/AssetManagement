using AssetManagement.Api.Controllers.AssetUsages;
using AssetManagement.Application.AssetUsages.CreateAssetUsage;
using AssetManagement.Application.AssetUsages.DeclineAssetUsage;
using AssetManagement.Application.AssetUsages.EndAssetUsage;
using AssetManagement.Application.AssetUsages.SearchAssetUsage;
using AssetManagement.Application.AssetUsages.SignAssetUsage;
using AssetManagement.Domain.AssetUsages;
using Azure.Core;
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
            request.PreviousAssetUsageId,
            request.PersonId,
            request.LocationId,
            request.StatusId
           );


          
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
    /// End AssetUsage, EndDate.
    /// </remarks>
    [HttpPut("AssetUsage_end/{id:int}")]
    public async Task<IActionResult> EndAssetUsage(
        int id,
        //[FromBody] EndAssetUsageRequest request,
        CancellationToken cancellationToken)
    {
        var command = new EndAssetUsageCommand(id);
            //id,
            //request.EndDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }
    
    
    /// <summary>
    /// Sign AssetUsage.
    /// </summary>
    /// <remarks>
    /// Sign AssetUsage, SignDate.
    /// </remarks>
    [HttpPut("AssetUsage_sign/{id:int}")]
    public async Task<IActionResult> SignAssetUsage(
        int id,
        //[FromBody] SignAssetUsageRequest request,
        CancellationToken cancellationToken)
    {
        var command = new SignAssetUsageCommand(id);
        //id,
        //request.SignDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    /// <summary>
    /// Decline AssetUsage.
    /// </summary>
    /// <remarks>
    /// Decline AssetUsage, DeclineDate.
    /// </remarks>
    [HttpPut("AssetUsage_decline/{id:int}")]
    public async Task<IActionResult> DeclineAssetUsage(
        int id,
        [FromBody] DeclineAssetUsageRequest request,
        CancellationToken cancellationToken)
    {
        var command = new DeclineAssetUsageCommand(id, request.AgreementDeclineReason);
        //id,
        //request.DeclineDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }


}


