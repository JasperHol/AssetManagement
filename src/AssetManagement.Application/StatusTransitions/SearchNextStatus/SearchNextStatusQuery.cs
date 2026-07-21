using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.StatusTransitions.SearchNextStatus;
public sealed record SearchNextStatusQuery(int Id) : IQuery<IReadOnlyList<NextStatusResponse>>;
