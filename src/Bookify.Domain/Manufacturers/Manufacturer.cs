using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Manufacturers.Events;
using AssetManagement.Domain.Shared;
using AssetManagement.Domain.Users;
using AssetManagement.Domain.Users.Events;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AssetManagement.Domain.Manufacturers;

public sealed class Manufacturer : Entity
{
    private Manufacturer(
        Guid id,
        Name name,
        Description description,
        Number number)
        : base(id)
    {

        Name = name;
        Description = description;
        Number = number;
    }

    private Manufacturer()
    {
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Number Number { get; private set; }


    public static Manufacturer Create(Name name, Description description, Number number)
    {
        var manufacturer = new Manufacturer(Guid.NewGuid(), name, description, number);

        manufacturer.RaiseDomainEvent(new ManufacturerCreatedDomainEvent(manufacturer.Id));

        return manufacturer;
    }

}