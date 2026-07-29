


using AssetManagement.Api.Controllers.Models;
using AssetManagement.Application.Statuses.SearchStatus;
using AssetManagement.Application.StatusTransitions.SearchNextStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;


namespace AssetManagement.Api.Controllers.Statuses

{
    [Route("api/AlleStatuses")]
    [ApiController]
    public class StatusController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all possible.
        /// </summary>
        /// <remarks>
        /// Lijst van alle mogelijke statusen ophalen.
        /// </remarks>
        [HttpGet("all_statuses")]
        public async Task<IActionResult> SearchStatus(
             CancellationToken cancellationToken)
        {
            var query = new SearchStatusesQuery();

            var result = await sender.Send(query, cancellationToken);

            return Ok(result.Value);
        } 
    }
    
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
