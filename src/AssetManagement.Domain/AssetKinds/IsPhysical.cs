using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetKinds;
public record IsPhysical(bool Value)
{
    public static IsPhysical True => new(true);
    public static IsPhysical False => new(false);

    public IsPhysical Toggle() => new(!Value);
}