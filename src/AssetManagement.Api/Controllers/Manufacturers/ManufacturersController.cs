

using AssetManagement.Application.Manufacturers.CreateManufacturer;
using AssetManagement.Application.Manufacturers.SearchManufacturer;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssetManagement.Api.Controllers.Manufacturers
{
    [Route("api/Manufacturers")]
    [ApiController]
    public class ManufacturersController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get All Manufacturers.
        /// </summary>
        /// <remarks>
        /// Lijst van alle Manufacturers ophalen.
        /// </remarks>
        [HttpGet("all_manufacturers")]
        public async Task<IActionResult> SearchManufacturers(CancellationToken cancellationToken)
        {
            var query = new SearchManufacturersQuery();

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create New Manufacturer.
        /// </summary>
        /// <remarks>
        /// Nieuwe Manufacturer toevoegen.
        /// </remarks>
        [HttpPost("manufacturer_create")]
        public async Task<IActionResult> CreateManufacturer(
            CreateManufacturerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateManufacturerCommand(
                request.Name,
                request.Description
                );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateManufacturer), new { id = result.Value }, result.Value);
        }
        ///// <summary>
        ///// Update Manufacturer.
        ///// </summary>
        ///// <remarks>
        ///// Requestable aanpassen zodat Manufacturer wel of niet gekozen kan worden.
        ///// </remarks>
        //[HttpPut("manufacturer_update")]
        //public async Task<IActionResult> UpdateManufacturer(UpdateManufacturerRequest request, CancellationToken cancellationToken)
        //{
        //    var command = new UpdateManufacturerCommand(
        //        request.Id,
        //        request.Requestable
        //    );

        //    var result = await _sender.Send(command, cancellationToken);

        //    if (result.IsFailure)
        //    {
        //        return BadRequest(result.Error);
        //    }

        //    return NoContent();
        //}



        /// <summary>
        /// Update Manufacturer.
        /// </summary>
        /// <remarks>
        /// Updates whether a manufacturer can be selected.
        /// </remarks>
        [HttpPut("manufacturer/{id:int}")]
        public async Task<IActionResult> UpdateManufacturer(
            int id,
            [FromBody] UpdateManufacturerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateManufacturerCommand(
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
