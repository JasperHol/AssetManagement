using AssetManagement.Api.Controllers.Manufacturers;
using AssetManagement.Api.Controllers.Models;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using AssetManagement.Application.Models.CreateModel;
using AssetManagement.Application.Models.SearchModel;
using AssetManagement.Application.Models.UpdateModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;


namespace AssetManagement.Api.Controllers.Models

{
    [Route("api/Models")]
    [ApiController]
    public class ModelsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all Models.
        /// </summary>
        /// <remarks>
        /// Lijst van alle modellen ophalen.
        /// </remarks>
        [HttpGet("all_models")]
        public async Task<IActionResult> SearchModels(CancellationToken cancellationToken)
        {
            var query = new SearchModelsQuery();

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create Model.
        /// </summary>
        /// <remarks>
        /// Nieuw model toevoegen.
        /// </remarks>
        [HttpPost("model_create")]
        public async Task<IActionResult> CreateModel(
            CreateModelRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateModelCommand(
                request.Name,
                request.Description,
                request.ManufacturerId
                );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateModel), new { id = result.Value }, result.Value);
        }

        /// <summary>
        /// Update Model.
        /// </summary>
        /// <remarks>
        /// Requestable aanpassen zodat een model wel of niet gekozen kan worden..
        /// </remarks>
        [HttpPut("model/{id:int}")]
        public async Task<IActionResult> UpdateManufacturer(
            int id,
            [FromBody] UpdateModelRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateModelCommand(
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
