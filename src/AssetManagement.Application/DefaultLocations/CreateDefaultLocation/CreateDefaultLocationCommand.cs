using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.DefaultLocations;
using AssetManagement.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.CreateDefaultLocation;
public record CreateDefaultLocationCommand(
        int StatusId,
        int LocationId,
        string Description)
    : ICommand<int>;