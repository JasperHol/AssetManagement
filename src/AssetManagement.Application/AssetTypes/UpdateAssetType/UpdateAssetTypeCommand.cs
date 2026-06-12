using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.UpdateAssetType;

public record UpdateAssetTypeCommand(int Id,
    bool Requestable)
    : ICommand<int>;