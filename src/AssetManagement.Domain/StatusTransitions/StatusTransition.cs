using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Manufacturers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.StatusTransitions;

public sealed class StatusTransition : Entity
{
    private StatusTransition(
        int statusFromId,
        int statusToId)
    {
        StatusFromId = statusFromId;
        StatusToId = statusToId;

    }

    private StatusTransition()
    {
    }
    public int StatusFromId { get; private set; }
    public int StatusToId { get; private set; }


    
}

