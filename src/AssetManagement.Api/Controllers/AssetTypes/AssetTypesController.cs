

using AssetManagement.Api.Controllers.Manufacturers;
using AssetManagement.Application.AssetTypes.CreateAssetType;
using AssetManagement.Application.AssetTypes.SearchAssetType;
using AssetManagement.Application.AssetTypes.UpdateAssetType;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssetManagement.Api.Controllers.AssetTypes
{
    [Route("api/AssetTypes")]
    [ApiController]
    public class AssetTypesController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get All AssetTypes.
        /// </summary>
        /// <remarks>
        /// Lijst van alle AssetTypes ophalen.
        /// </remarks>
        [HttpGet("all_assetTypes")]
        public async Task<IActionResult> SearchAssetTypes(CancellationToken cancellationToken)
        {
            var query = new SearchAssetTypesQuery();

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create New AssetType.
        /// </summary>
        /// <remarks>
        /// Nieuwe AssetType toevoegen.
        /// </remarks>
        [HttpPost("assetType_create")]
        public async Task<IActionResult> CreateAssetType(
            CreateAssetTypeRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateAssetTypeCommand(
                request.Name,
                request.Description,
                request.Requestable,
                request.DepreciationValue,
                request.DepreciationPeriod,
                request.DataSource,
                request.JiraId,
                request.PrefixName,
                request.SecuritySensitive,
                request.MobileEquipment,
                request.ModelId,
                request.AssetKindId
                );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateAssetType), new { id = result.Value }, result.Value);
        }
        /// <summary>
        /// Update AssetType.
        /// </summary>
        /// <remarks>
        /// Requestable aanpassen zodat AssetType wel of niet gekozen kan worden.
        /// </remarks>
        [HttpPut("assetType/{id:int}")]
        public async Task<IActionResult> UpdateAssetType(
            int id,
            [FromBody] UpdateAssetTypeRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateAssetTypeCommand(
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
