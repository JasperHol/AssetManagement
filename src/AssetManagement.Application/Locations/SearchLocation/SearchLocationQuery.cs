using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.SearchLocation;

public sealed record SearchLocationQuery() : IQuery<IReadOnlyList<LocationResponse>>;