using AssetManagement.Application.AssetUsages.EndAssetUsage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.EndAssetUsage;

public sealed class EndAssetUsageCommandValidator
    : AbstractValidator<EndAssetUsageCommand>
{
    public EndAssetUsageCommandValidator()
    {
        //RuleFor(c => c.EndDate)
        //     .NotEmpty();

    }
}
