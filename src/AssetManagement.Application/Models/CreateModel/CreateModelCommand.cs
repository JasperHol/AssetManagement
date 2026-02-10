using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.CreateModel;
public record CreateModelCommand(
    string Name,
    string Description,
    int ManufacturerId)
    : ICommand<int>;