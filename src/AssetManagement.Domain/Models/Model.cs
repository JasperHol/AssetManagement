using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Models;

public sealed class Model : Entity
{
    private Model(
        Name name,
        Description description,
        Requestable requestable,
        int manufacturerId)
    {
        Name = name;
        Description = description;
        Requestable = requestable;
        ManufacturerId = manufacturerId;
    }


    private Model()
    {
    }
    public int Id { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Requestable Requestable { get; private set; }
    public int ManufacturerId { get; private set; }

    public static Model Create(
        Name name,
        Description description,
        int manufacturerId,
        Requestable? requestable = null)

    {
        var model = new Model(
            name,
            description,
            requestable ?? Requestable.True,
            manufacturerId);

        model.RaiseDomainEvent(
            new ModelCreatedDomainEvent(
                model.Name,
                model.Description,
                model.Requestable,
                model.ManufacturerId));

        return model;
    }
    public void ToggleRequestable()
    {
        Requestable = Requestable.Toggle();

        RaiseDomainEvent(new ModelUpdatedDomainEvent(Id, Requestable));
    }



}

