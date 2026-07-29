using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.DefaultLocations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.DefaultLocations;

public sealed class DefaultLocation : Entity
{
    private DefaultLocation(
        int statusId,
        int locationId,
        Description description)
    {

        StatusId = statusId;
        LocationId = locationId;
        Description = description;

     }


    private DefaultLocation()
    {
    }
    public int Id { get; private set; }
    public int StatusId { get; private set; }
    public int LocationId { get; private set; }
    public Description Description { get; private set; }
       
    public static DefaultLocation Create(
        int statusId,
        int locationId,
        Description description)

    {
        var defaultLocation = new DefaultLocation(
            statusId,
            locationId,
            description);

        defaultLocation.RaiseDomainEvent(
            new DefaultLocationCreatedDomainEvent(
                defaultLocation.StatusId,
                defaultLocation.LocationId,
                defaultLocation.Description));

        return defaultLocation;
    }

    
    public void ChangeDescription(Description description)
    {
        Description = description;

        RaiseDomainEvent(
            new DefaultLocationUpdatedDomainEvent(Id, Description));


    }
}

