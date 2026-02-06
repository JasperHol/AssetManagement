
using AssetManagement.Api.Controllers.Users;

using AssetManagement.Application.Users.CreateUser;
using AssetManagement.Application.Users.SearchUsers;
using AssetManagement.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Users
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("Search_Users")]
        public async Task<IActionResult> SearchUsers(string first_Name, string last_Name, CancellationToken cancellationToken)
        {
            var query = new SearchUsersQuery(first_Name, last_Name);

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result);
        }


        [HttpPost("user_create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request,CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.DateOfBirth);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(CreateUser), new { id = result.Value }, result.Value);
        }






    }
}
