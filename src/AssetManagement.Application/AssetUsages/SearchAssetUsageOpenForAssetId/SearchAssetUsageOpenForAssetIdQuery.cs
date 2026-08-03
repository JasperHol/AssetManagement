using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsageOpenForAssetId;
public sealed record SearchAssetUsageOpenForAssetIdQuery(int Id) : IQuery<IReadOnlyList<AssetUsageOpenForAssetIdResponse>>;
