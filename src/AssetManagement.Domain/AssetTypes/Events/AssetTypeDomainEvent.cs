using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetTypes.Events;

public sealed record AssetTypeCreatedDomainEvent(int AssetType,Name Name, Description Description, Requestable Requestable) : IDomainEvent;

public sealed record AssetTypeUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;




