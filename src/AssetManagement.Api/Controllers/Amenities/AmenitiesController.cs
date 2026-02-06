

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Manufacturers
{
    //[Route("api/Manufacturers")]
    //[ApiController]
    //public class AmenitiesController : ControllerBase
    //{
    //    private readonly ISender _sender;

    //    public AmenitiesController(ISender sender)
    //    {
    //        _sender = sender;
    //    }

    //    [HttpGet("all_amenities")]
    //    public async Task<IActionResult> SearchAmenities(

    //        CancellationToken cancellationToken)
    //    {
    //        var query = new SearchAmenitiesQuery();

    //        var result = await _sender.Send(query, cancellationToken);

    //        return Ok(result.Value);
    //    }


    //    [HttpPost("amenity_create")]
    //    public async Task<IActionResult> CreateAmenity(
    //        CreateAmenityRequest request,
    //        CancellationToken cancellationToken)
    //    {
    //        var command = new CreateAmenityCommand(
    //            request.Name,
    //            request.Description,
    //            request.Number);

    //        var result = await _sender.Send(command, cancellationToken);

    //        if (result.IsFailure)
    //        {
    //            return BadRequest(result.Error);
    //        }

    //        return CreatedAtAction(nameof(CreateAmenity), new { id = result.Value }, result.Value);
    //    }

    //}
}
