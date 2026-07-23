using AssetManagement.Api.Controllers.Manufacturers;
using AssetManagement.Api.Controllers.Locations;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using AssetManagement.Application.Locations.CreateLocation;
using AssetManagement.Application.Locations.SearchLocation;
using AssetManagement.Application.Locations.UpdateLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;


namespace AssetManagement.Api.Controllers.Locations

{
    [Route("api/Locations")]
    [ApiController]
    public class LocationsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all Locations.
        /// </summary>
        /// <remarks>
        /// Lijst van alle locations ophalen.
        /// </remarks>
        [HttpGet("all_locations")]
        public async Task<IActionResult> SearchLocations(CancellationToken cancellationToken)
        {
            var query = new SearchLocationQuery();

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create Location.
        /// </summary>
        /// <remarks>
        /// Nieuw location toevoegen.
        /// </remarks>
        [HttpPost("location_create")]
        public async Task<IActionResult> CreateLocation(
            CreateLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateLocationCommand(
                request.BuildingId,
                request.PersonId,
                request.ReportingUnitId,
                request.Name,
                request.Remark,
                request.Requestable
                );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateLocation), new { id = result.Value }, result.Value);
        }

        /// <summary>
        /// Update Location.
        /// </summary>
        /// <remarks>
        /// Requestable aanpassen zodat een location wel of niet gekozen kan worden..
        /// </remarks>
        [HttpPut("location/{id:int}")]
        public async Task<IActionResult> UpdateManufacturer(
            int id,
            [FromBody] UpdateLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateLocationCommand(
                id,
                request.Requestable);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

    }
}
