using AssetManagement.Application.Auditing.SearchAudit;



using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Auditing;


[Route("api/Auditing")]
[ApiController]
public class AuditingController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Get All Auditing.
    /// </summary>
    /// <remarks>
    /// Lijst van alle Auditing ophalen.
    /// </remarks>
    [HttpGet("all_auditing")]
    public async Task<IActionResult> SearchAuditing(CancellationToken cancellationToken)
    {
        var query = new SearchAuditingQuery();

        var result = await sender.Send(query, cancellationToken);

        //return Ok(result.ToString());
        return Ok(result.Value);
    }
}


   

