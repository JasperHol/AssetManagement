using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.CreateManufacturer;

public record CreateManufacturerCommand(
    string Name,
    string Description)
    : ICommand<int>;