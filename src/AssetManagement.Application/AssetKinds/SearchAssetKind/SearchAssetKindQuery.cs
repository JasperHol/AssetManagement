using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.SearchAssetKind;

public sealed record SearchAssetKindsQuery() : IQuery<IReadOnlyList<AssetKindResponse>>;