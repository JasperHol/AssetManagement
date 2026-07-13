using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetKinds.Events;
using AssetManagement.Domain.Shared;

namespace AssetManagement.Domain.AssetKinds;

public sealed class AssetKind : Entity
{
    

    private AssetKind(
        Name name,
        HasMacAddress hasMacAddress,
        IsPhysical isPhysical)
    {
        Name = name;
        HasMacAddress = hasMacAddress;
        IsPhysical = isPhysical;

    }

    private AssetKind()
    {
    }

   
    public int Id { get; private set; }
    public Name Name { get; private set; } 
    public HasMacAddress HasMacAddress { get; private set; } = default!;
    public IsPhysical IsPhysical { get; private set; } = default!;


    public static AssetKind Create(
        Name name,
        HasMacAddress? hasMacAddress = null,
        IsPhysical? isPhysical = null)
    {
        var assetKind = new AssetKind(
            name,
            hasMacAddress ?? HasMacAddress.True,
            isPhysical ?? IsPhysical.True);

        assetKind.RaiseDomainEvent(
            new AssetKindCreatedDomainEvent(
                assetKind.Name,
                assetKind.HasMacAddress,
                assetKind.IsPhysical));

        return assetKind;
    }

    public void ToggleIsPhysical()
    {
        IsPhysical = IsPhysical.Toggle();

        RaiseDomainEvent(
            new AssetKindPhysicalChangedDomainEvent(
           
                IsPhysical));
    }

    public void ToggleHasMacAddress()
    {
        HasMacAddress = HasMacAddress.Toggle();

        RaiseDomainEvent(
            new AssetKindHasMacAddressChangedDomainEvent(
              
                HasMacAddress));
    }



}