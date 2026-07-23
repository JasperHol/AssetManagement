using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Locations.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Locations;

public sealed class Location : Entity
{
    private Location(
        int buildingId,
        int personId,
        int reportingUnitId,
        Name name,
        Remark remark,
        Requestable requestable)
    {
        
        BuildingId = buildingId;
        PersonId = personId;
        ReportingUnitId = reportingUnitId;
        Name = name;
        Remark = remark;
        Requestable = requestable;
     }


    private Location()
    {
    }
    public int Id { get; private set; }
    public int BuildingId { get; private set; }
    public int PersonId { get; private set; }
    public int ReportingUnitId { get; private set; }

    public Name Name { get; private set; }
    public Remark Remark  { get; private set; }
    public Requestable Requestable { get; private set; }
    
    public static Location Create(
        int buildingId,
        int personId,
        int reportingUnitId,
        Name name,
        Remark remark,
        Requestable? requestable = null)

    {
        var location = new Location(
            buildingId,
            personId,
            reportingUnitId,
            name,
            remark,
            requestable ?? Requestable.True
            );

        location.RaiseDomainEvent(
            new LocationCreatedDomainEvent(
                location.BuildingId,
                location.PersonId,
                location.ReportingUnitId,
                location.Name,
                location.Remark,
                location.Requestable));

        return location;
    }
    public void ToggleRequestable()
    {
        Requestable = Requestable.Toggle();

        RaiseDomainEvent(new LocationUpdatedDomainEvent(Id, Requestable));
    }
    public void ChangeRequestable(Requestable requestable)
    {
        Requestable = requestable;

        RaiseDomainEvent(
            new LocationUpdatedDomainEvent(Id, Requestable));


    }
}

