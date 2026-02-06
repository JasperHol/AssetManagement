using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Users.Events;

namespace AssetManagement.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, FirstName firstName, LastName lastName, Email email, DateOnly dateOfBirth)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    private User()
    {
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }


    public DateOnly? DateOfBirth { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email, DateOnly dateOfBirth)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email, dateOfBirth);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}