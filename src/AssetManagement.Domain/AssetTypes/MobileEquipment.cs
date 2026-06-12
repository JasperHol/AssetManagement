using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetTypes;


public record MobileEquipment(bool Value)
{
    public static MobileEquipment True => new(true);
    public static MobileEquipment False => new(false);

    public MobileEquipment Toggle() => new(!Value);
}