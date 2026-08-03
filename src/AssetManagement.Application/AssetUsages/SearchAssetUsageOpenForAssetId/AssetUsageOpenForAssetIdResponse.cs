using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsageOpenForAssetId;

public sealed class AssetUsageOpenForAssetIdResponse
{
    public int Id { get; init; }

    public string Name { get; init; }
    public string SerialNumber { get; init; }
    public string MacAddress { get; init; }
    public string ServiceTag { get; init; }
    public DateOnly PurchaseDate { get; init; }
    public string OrderNumber { get; init; }
    public DateTime LostDate { get; init; }
    public DateTime DisposedDate { get; init; }
    public string CmdbLabel { get; init; }
    public DateOnly DepreciationDate { get; init; }
    public int MsLicenceMappingId { get; init; }
    public int StatusId { get; init; }
    public int AssetTypeId { get; init; }


}