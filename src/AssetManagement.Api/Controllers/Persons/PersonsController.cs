using AssetManagement.Api.Controllers.Persons;
using AssetManagement.Application.Persons.CreatePerson;
using AssetManagement.Application.Persons.SearchPerson;
using AssetManagement.Application.Persons.UpdatePerson;
using AssetManagement.Domain.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Bogus.DataSets.Name;


namespace AssetManagement.Api.Controllers.Persons

{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Get all Persons.
        /// </summary>
        /// <remarks>
        /// Lijst van alle persons ophalen.
        /// </remarks>
        [HttpGet("all_persons")]
        public async Task<IActionResult> SearchPersons(CancellationToken cancellationToken)
        {
            var query = new SearchPersonsQuery();

            var result = await sender.Send(query, cancellationToken);

            //return Ok(result.ToString());
            return Ok(result.Value);
        }

        /// <summary>
        /// Create Person.
        /// </summary>
        /// <remarks>
        /// Nieuw person toevoegen.
        /// </remarks>
        [HttpPost("person_create")]
        public async Task<IActionResult> CreatePerson(
            CreatePersonRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreatePersonCommand(
                request.Name,
                request.Requestable,
                request.EmailAddress,
                request.EmloyeeNumber,
                request.DataSource,
                request.Sid,
                request.AccountName,
                request.WorksForId);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreatePerson), new { id = result.Value }, result.Value);
        }

        /// <summary>
        /// Update Person.
        /// </summary>
        /// <remarks>
        /// Requestable aanpassen zodat een person wel of niet gekozen kan worden.
        /// </remarks>
        [HttpPut("person/{id:int}")]
        public async Task<IActionResult> UpdateManufacturer(
            int id,
            [FromBody] UpdatePersonRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdatePersonCommand(
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
