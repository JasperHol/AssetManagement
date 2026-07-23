using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.UpdateLocation;

public record Requestable(bool Value)
{
    public static Requestable True => new(true);
    public static Requestable False => new(false);

    public Requestable Toggle() => new(!Value);
}