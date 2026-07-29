
using AssetManagement.Application.DefaultLocations.CreateDefaultLocation;
using AssetManagement.Application.DefaultLocations.SearchDefaultLocation;
using AssetManagement.Application.DefaultLocations.UpdateDefaultLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;

namespace AssetManagement.Api.Controllers.DefaultLocations

{
    [Route("api/DefaultLocations")]
    [ApiController]
    public class DefaultLocationsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all Locations.
        /// </summary>
        /// <remarks>
        /// Lijst van alle default locations ophalen.
        /// </remarks>
        [HttpGet("all_defaultLocations")]
        public async Task<IActionResult> SearchLocations(CancellationToken cancellationToken)
        {
            var query = new SearchDefaultLocationQuery();

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
        /// Description aanpassen.
        /// </remarks>
        [HttpPut("default_location_update/{id:int}")]
        public async Task<IActionResult> UpdateDefaultLocation(
            int id,
            [FromBody] UpdateDefaultLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateDefaultLocationCommand(
                id,
                request.Description);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

    }
}
