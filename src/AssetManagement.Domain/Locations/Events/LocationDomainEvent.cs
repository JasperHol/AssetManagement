using AssetManagement.Domain.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Locations.Events;
public sealed record LocationCreatedDomainEvent(
        int buildingId,
        int personId,
        int reportingUnitId,
        Name name,
        Remark remark,
        Requestable requestable) : IDomainEvent;
public sealed record LocationUpdatedDomainEvent(int Id, Requestable Requestable) : IDomainEvent;
