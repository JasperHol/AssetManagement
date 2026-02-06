using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Users.CreateUser;
public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    DateOnly DateOfBirth) : ICommand<Guid>;




