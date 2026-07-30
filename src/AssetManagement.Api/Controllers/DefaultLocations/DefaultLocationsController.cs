
using AssetManagement.Api.Controllers.Assets;
using AssetManagement.Application.DefaultLocations.CreateDefaultLocation;
using AssetManagement.Application.DefaultLocations.SearchDefaultLocation;
using AssetManagement.Application.DefaultLocations.SearchDefaultLocationFromStatus;

using AssetManagement.Domain.Statuses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;

namespace AssetManagement.Api.Controllers.DefaultLocations

{
    [Route("api/DefaultLocations")]
    [ApiController]
    public class DefaultLocationsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all Default Locations.
        /// </summary>
        /// <remarks>
        /// Lijst van alle default locations ophalen.
        /// </remarks>
        [HttpGet("all_defaultLocations")]
        public async Task<IActionResult> SearchDefaultLocations(CancellationToken cancellationToken)
        {
            var query = new SearchDefaultLocationQuery();

            var result = await sender.Send(query, cancellationToken);

       ;
            return Ok(result.Value);
        }

        /// <summary>
        /// Get Default Location from Status.
        /// </summary>
        /// <remarks>
        /// Lijst van alle default locations ophalen.
        /// </remarks>
        [HttpGet("defaultLocation_from_status/{id}")]
        public async Task<IActionResult> SearchDefaultLocationFromStatus(
            StatusId id, 
            CancellationToken cancellationToken)
        {
            var query = new SearchDefaultLocationFromStatusQuery((int)id); 

            var result = await sender.Send(query, cancellationToken);

            ;
            return Ok(result.Value);
        }

        /// <summary>
        /// Create Default Location.
        /// </summary>
        /// <remarks>
        /// Nieuw default location toevoegen.
        /// </remarks>
        [HttpPost("default_location_create")]


        public async Task<IActionResult> CreateDefaultLocation(
            CreateDefaultLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateDefaultLocationCommand(
                request.StatusId,
                request.LocationId,
                request.Description
                );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateDefaultLocation), new { id = result.Value }, result.Value);
        }

        /// <summary>
        /// Update Location.
        /// </summary>
        /// <remarks>
        /// Description van de default location aanpassen.
        /// </remarks>
        [HttpPut("default_location_update/{id:int}")]
        public async Task<IActionResult> UpdateDefaultLocation(
            int id,
            [FromBody] UpdateDefaultLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AssetManagement.Application.DefaultLocations.UpdateDefaultLocation.UpdateDefaultLocationCommand(
                id,
                request.Description);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        /// <summary>
        /// Change Location.
        /// </summary>
        /// <remarks>
        /// Locatie van de default location aanpassen.
        /// </remarks>
        [HttpPut("default_location_change/{statusid:int}")]
        public async Task<IActionResult> changeDefaultLocation(
            int statusid,
            [FromBody] ChangeDefaultLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new AssetManagement.Application.DefaultLocations.ChangeDefaultLocation.ChangeDefaultLocationCommand(
                statusid,
                request.LocationId);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

    }
}
