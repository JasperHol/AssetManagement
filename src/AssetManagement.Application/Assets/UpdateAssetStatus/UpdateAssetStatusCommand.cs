using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.UpdateAssetStatus;

public record UpdateAssetStatusCommand(int Id, int StatusId)   : ICommand<int>;