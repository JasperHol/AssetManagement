using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Persons.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Persons;

public sealed class Person : Entity
{
    private Person(
        Name name,
        Requestable requestable,
        EmailAddress emailAddress,
        EmloyeeNumber emloyeeNumber,
        DataSource dataSource,
        Sid sid,
        AccountName accountName,
        int worksForId)
    {
        Name = name;
        Requestable = requestable;
        EmailAddress = emailAddress;
        EmloyeeNumber = emloyeeNumber;
        DataSource = dataSource;
        Sid = sid;
        AccountName = accountName;
        WorksForId = worksForId;   
    }


    private Person()
    {
    }
    public int Id { get; private set; }
    public Name Name { get; private set; }
    public Requestable Requestable { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public EmloyeeNumber EmloyeeNumber { get; private set; }
    public DataSource DataSource { get; private set; }
    public Sid Sid { get; private set; }
    public AccountName AccountName { get; private set; }
    public int WorksForId { get; private set; }


    public static Person Create(
        Name name,
        Requestable requestable,
        EmailAddress emailAddress,
        EmloyeeNumber emloyeeNumber,
        DataSource dataSource,
        Sid sid,
        AccountName accountName,
        int worksForId)

    {
        var person = new Person(
            name,
            requestable ?? Requestable.True,
            emailAddress,
            emloyeeNumber,
            dataSource,
            sid,
            accountName,
            worksForId
            );

        person.RaiseDomainEvent(
            new PersonCreatedDomainEvent(
                person.Name,
                person.Requestable,
                person.EmailAddress,
                person.EmloyeeNumber,
                person.DataSource,
                person.Sid,
                person.AccountName,
                person.WorksForId));

        return person;
    }
    public void ToggleRequestable()
    {
        Requestable = Requestable.Toggle();

        RaiseDomainEvent(new PersonUpdatedDomainEvent(Id, Requestable));
    }
    public void ChangeRequestable(Requestable requestable)
    {
        Requestable = requestable;

        RaiseDomainEvent(
            new PersonUpdatedDomainEvent(Id, Requestable));


    }
}

