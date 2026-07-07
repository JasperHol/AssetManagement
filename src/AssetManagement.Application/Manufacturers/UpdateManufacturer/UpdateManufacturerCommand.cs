using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.UpdateManufacturer;

public record UpdateManufacturerCommand(int Id, bool Requestable)   : ICommand<int>;