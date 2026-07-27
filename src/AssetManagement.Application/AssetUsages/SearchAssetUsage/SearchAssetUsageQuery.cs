using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsage;
public sealed record SearchAssetUsageQuery() : IQuery<IReadOnlyList<AssetUsageResponse>>;
