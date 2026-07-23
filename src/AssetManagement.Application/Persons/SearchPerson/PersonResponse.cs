using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.SearchPerson;

public sealed class PersonResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Requestable { get; init; }

    public string EmailAddress { get; init; }

    public string EmloyeeNumber { get; init; }
    public string DataSouce { get; init; }
    public string Sid { get; init; }
    public string AccountName { get; init; }
    public int WorksForId { get; init; }


}
