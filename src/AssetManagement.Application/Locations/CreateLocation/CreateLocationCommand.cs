using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Locations;
using AssetManagement.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.CreateLocation;
public record CreateLocationCommand(
        int BuildingId,
        int PersonId,
        int ReportingUnitId,
        string Name,
        string Remark,
        bool Requestable)
    : ICommand<int>;