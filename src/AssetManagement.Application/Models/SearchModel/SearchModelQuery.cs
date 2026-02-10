using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.SearchModel;

public sealed record SearchModelsQuery() : IQuery<IReadOnlyList<ModelResponse>>;