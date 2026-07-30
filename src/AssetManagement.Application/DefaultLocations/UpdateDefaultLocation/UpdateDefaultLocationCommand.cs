using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.UpdateDefaultLocation;

public record UpdateDefaultLocationCommand(int Id, string Description)   : ICommand<int>;
public record ChangeDefaultLocationCommand(int StatusId, int LocationId) : ICommand<int>;