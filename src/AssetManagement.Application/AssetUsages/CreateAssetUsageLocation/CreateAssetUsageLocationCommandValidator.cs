using AssetManagement.Application.AssetUsages.CreateAssetUsageLocation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsageLocations.CreateAssetUsageLocation;

public sealed class CreateAssetUsageLocationCommandValidator
    : AbstractValidator<CreateAssetUsageLocationCommand>
{
    public CreateAssetUsageLocationCommandValidator()
    {
        //RuleFor(c => c.StartDate)
        //    .NotEmpty();

     


    }
}