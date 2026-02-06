using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Amenities.Events;

public sealed record AmenityCreatedDomainEvent(Guid AmenityID) : IDomainEvent;
