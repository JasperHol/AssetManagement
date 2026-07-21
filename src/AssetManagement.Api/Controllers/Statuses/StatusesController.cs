


using AssetManagement.Api.Controllers.Models;
using AssetManagement.Application.StatusTransitions.SearchNextStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;


namespace AssetManagement.Api.Controllers.Statuses

{
    [Route("api/NextStatus")]
    [ApiController]
    public class NextStatusController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all next possible statuses from current status.
        /// </summary>
        /// <remarks>
        /// Lijst van alle mogelijke statusen ophalen die mogelijk zijn vanaf de huidige status.
        /// </remarks>
        [HttpGet("all_nextstatuses/{id:int}")]
        public async Task<IActionResult> SearchNextStatus(
             int id,
             CancellationToken cancellationToken)
        {
            var query = new SearchNextStatusQuery(id);

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        
  

    }
}
