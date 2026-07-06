using AssetManagement.Api.Controllers.Models;
using AssetManagement.Application.Models.CreateModel;
using AssetManagement.Application.Models.SearchModel;
using AssetManagement.Application.Models.UpdateModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Bogus.DataSets.Name;
using Swashbuckle.AspNetCore.Annotations;


namespace AssetManagement.Api.Controllers.Models

{
    [Route("api/Models")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly ISender _sender;

        public ModelsController(ISender sender)
        {
            _sender = sender;
        }
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

            var result = await _sender.Send(query, cancellationToken);

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

            var result = await _sender.Send(command, cancellationToken);

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
        [HttpPut("model_update")]
        public async Task<IActionResult> UpdateModel(
        UpdateModelRequest request,
        CancellationToken cancellationToken)
        {
            var command = new UpdateAssetKindlCommand(
                request.Id,
                request.Requestable
            );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

    }
}
