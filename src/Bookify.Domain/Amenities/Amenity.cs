using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Amenities.Events;
using AssetManagement.Domain.Shared;
using AssetManagement.Domain.Users;
using AssetManagement.Domain.Users.Events;

namespace AssetManagement.Domain.Amenities;

public sealed class Amenity : Entity
{
    private Amenity(
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

    private Amenity()
    {
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Number Number { get; private set; }


    public static Amenity Create(Name name, Description description, Number number)
    {
        var amenity = new Amenity(Guid.NewGuid(), name, description, number);

        amenity.RaiseDomainEvent(new AmenityCreatedDomainEvent(amenity.Id));

        return amenity;
    }

}