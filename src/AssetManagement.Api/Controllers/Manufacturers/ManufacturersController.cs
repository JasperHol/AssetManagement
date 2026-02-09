

using AssetManagement.Application.Manufacturers.CreateManufacturer;
using AssetManagement.Application.Manufacturers.SearchManufacturer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Manufacturers
{
    [Route("api/Manufacturers")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ISender _sender;

        public ManufacturersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("all_manufacturers")]
        public async Task<IActionResult> SearchManufacturers(CancellationToken cancellationToken)
        {
            var query = new SearchManufacturersQuery();

            var result = await _sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }


        [HttpPost("manufacturer_create")]
        public async Task<IActionResult> CreateManufacturer(
            CreateManufacturerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateManufacturerCommand(
                request.Name,
                request.Description
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateManufacturer), new { id = result.Value }, result.Value);
        }

    }
}
