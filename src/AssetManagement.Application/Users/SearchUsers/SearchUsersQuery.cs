using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Users.SearchUsers;


public sealed record SearchUsersQuery(string First_Name,string Last_Name) : IQuery<IReadOnlyList<UserResponse>>;



