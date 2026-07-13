using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.CreateAssetKind;
public record CreateAssetCommand(string Name,bool HasMacAddress,bool IsPhysical)    : ICommand<int>;