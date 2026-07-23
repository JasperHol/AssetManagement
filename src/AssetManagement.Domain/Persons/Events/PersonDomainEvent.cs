using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Persons.Events;
public sealed record PersonCreatedDomainEvent(
    Name Name,
    Requestable Requestable,
    EmailAddress EmailAddress,
    EmloyeeNumber EmloyeeNumber,
    DataSource DataSource,
    Sid Sid,
    AccountName AccountName,
    int WorksForId) : IDomainEvent;




public sealed record PersonUpdatedDomainEvent(int Id, Requestable Requestable) : IDomainEvent;
