using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers.Events;
//using AssetManagement.Domain.Models;
using AssetManagement.Domain.Shared;

namespace AssetManagement.Domain.Manufacturers;


public sealed class Manufacturer : Entity
{
    private Manufacturer(
        Name name,
        Description description,
        Requestable requestable)
    {
        Name = name;
        Description = description;
        Requestable = requestable;
    }

    private Manufacturer()
    {
    }
    public AssetManagement.Domain.Models.ManufacturerId Id { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Requestable Requestable { get; private set; }

    public static Manufacturer Create(
        Name name,
        Description description,
        Requestable? requestable = null)
    {
        var manufacturer = new Manufacturer(
            name,
            description,
            requestable ?? Requestable.True);

        manufacturer.RaiseDomainEvent(
            new ManufacturerCreatedDomainEvent(
                manufacturer.Name,
                manufacturer.Description,
                manufacturer.Requestable));

        return manufacturer;
    }
    public void ToggleRequestable()
    {
        Requestable = Requestable.Toggle();

        RaiseDomainEvent(
            new ManufacturerUpdatedDomainEvent(Id,Requestable));
    }


}

