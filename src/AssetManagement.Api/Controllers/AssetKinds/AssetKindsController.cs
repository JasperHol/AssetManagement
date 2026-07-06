

using AssetManagement.Application.AssetKinds.CreateAssetKind;
using AssetManagement.Application.AssetKinds.SearchAssetKind;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssetManagement.Api.Controllers.AssetKinds
{
    [Route("api/AssetKinds")]
    [ApiController]
    public class AssetKindsController : ControllerBase
    {
        private readonly ISender _sender;

        public AssetKindsController(ISender sender)
        {
            _sender = sender;
        }
        /// <summary>
        /// Get All AssetKinds.
        /// </summary>
        /// <remarks>
        /// Lijst van alle AssetKinds ophalen.
        /// </remarks>
        [HttpGet("all_AssetKinds")]
        public async Task<IActionResult> SearchAssetKinds(CancellationToken cancellationToken)
        {
            var query = new SearchAssetKindsQuery();

            var result = await _sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create New AssetKind.
        /// </summary>
        /// <remarks>
        /// Nieuwe AssetKind toevoegen.
        /// </remarks>
        [HttpPost("AssetKind_create")]
        public async Task<IActionResult> CreateAssetKind(
            CreateAssetKindRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateAssetKindCommand(
                request.Name,
                request.HasMacAddress,
                request.IsPhysical

                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateAssetKind), new { id = result.Value }, result.Value);
        }
        

    }
}
