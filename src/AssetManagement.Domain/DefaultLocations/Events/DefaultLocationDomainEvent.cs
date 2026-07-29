using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.DefaultLocations.Events;
public sealed record DefaultLocationCreatedDomainEvent(
        int statusId,
        int locationId,
        Description description) : IDomainEvent;
public sealed record DefaultLocationUpdatedDomainEvent(int Id, Description description) : IDomainEvent;
