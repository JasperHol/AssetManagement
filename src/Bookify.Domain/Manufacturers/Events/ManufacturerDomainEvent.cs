using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Manufacturers.Events;

public sealed record ManufacturerCreatedDomainEvent(Guid AmenityID) : IDomainEvent;
