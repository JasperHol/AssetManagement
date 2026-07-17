using AssetManagement.Domain.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Statuses;

public sealed class Status : Entity
{
    private int StatusTranstionId;

    private Status(
     int id,
     Name name,
     int statusTransitionId)
    {
        Id = id;
        Name = name;
        StatusTransitionId = statusTransitionId;
    }


    private Status()
    {
    }
    public Name Name  { get; private set; }
    public int StatusTransitionId { get; private set; }

    public static Status Create(
    int id,
    Name name,
    int statusTransitionId)
    {
        return new Status
        {
            Id = id,
            Name = name,
            StatusTranstionId = statusTransitionId
        };
    }

    public void Update(
        Name name,
        int statusTransitionId)
    {
        Name = name;
        StatusTranstionId = statusTransitionId;
    }

}

