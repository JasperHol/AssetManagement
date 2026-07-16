using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Statuses;

public sealed class Status : Entity
{
    private Status(
        Name name,
        int statusTransitionId)
    {
        Name = name;
        StatusTransitionId = statusTransitionId;

    }

    private Status()
    {
    }

    public int Id { get; private set; }
    public Name Name { get; private set; }
    public int StatusTransitionId { get; private set; }



}

