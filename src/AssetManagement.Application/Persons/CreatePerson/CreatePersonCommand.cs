using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.CreatePerson;
public record CreatePersonCommand(
    string Name,
    bool Requestable,
    string EmailAddress,
    string EmloyeeNumber,
    string DataSource,
    string Sid,
    string AccountName,     
    int WorksForId) : ICommand<int>;