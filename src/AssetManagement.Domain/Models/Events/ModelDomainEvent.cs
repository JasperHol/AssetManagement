using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Models.Events;
public sealed record ModelCreatedDomainEvent(Name Name, Description Description, Requestable Requestable, int ManufacturerId) : IDomainEvent;
public sealed record ModelUpdatedDomainEvent(int Id, Requestable Requestable) : IDomainEvent;
