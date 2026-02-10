using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Manufacturers.Events;

public sealed record ManufacturerCreatedDomainEvent(Name Name, Description Description, Requestable Requestable) : IDomainEvent;
public sealed record ManufacturerUpdatedDomainEvent(ManufacturerId Id, Requestable Requestable) : IDomainEvent;
