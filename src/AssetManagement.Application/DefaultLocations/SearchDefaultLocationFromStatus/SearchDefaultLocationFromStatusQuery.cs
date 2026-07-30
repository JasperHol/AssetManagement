using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.SearchDefaultLocationFromStatus;

public sealed record SearchDefaultLocationFromStatusQuery(int Id) : IQuery<IReadOnlyList<DefaultLocationFromStatusResponse>>;