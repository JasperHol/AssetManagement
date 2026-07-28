using AssetManagement.Application.AssetUsages.DeclineAssetUsage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.DeclineAssetUsage;

public sealed class DeclineAssetUsageCommandValidator
    : AbstractValidator<DeclineAssetUsageCommand>
{
    public DeclineAssetUsageCommandValidator()
    {
       // RuleFor(c => c.Requestable)
       //     .NotEmpty();

    }
}
