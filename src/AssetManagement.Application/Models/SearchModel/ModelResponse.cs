using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.SearchModel;

public sealed class ModelResponse
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public bool Requestable { get; init; }


}
