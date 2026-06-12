using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetTypes;


public record SecuritySensitive(bool Value)
{
    public static SecuritySensitive True => new(true);
    public static SecuritySensitive False => new(false);

    public SecuritySensitive Toggle() => new(!Value);
}