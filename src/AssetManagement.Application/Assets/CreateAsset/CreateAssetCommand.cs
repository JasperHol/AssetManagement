using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.CreateAsset;
public record CreateAssetCommand(string Name, string Brand, string Model, string SerialNumber, string MacAddress, string ServiceTag, DateOnly PurchaseDate, string OrderNumber, DateTime LostDate, DateOnly DisposedDate, string CmdbLabel, DateOnly DepreciationDate)    : ICommand<int>;