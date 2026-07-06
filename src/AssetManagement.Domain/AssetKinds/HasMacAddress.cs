using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetKinds;


public record HasMacAddress(bool Value)
{
    public static HasMacAddress True => new(true);
    public static HasMacAddress False => new(false);

    public HasMacAddress Toggle() => new(!Value);
}