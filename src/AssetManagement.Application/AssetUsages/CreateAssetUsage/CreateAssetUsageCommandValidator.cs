using AssetManagement.Application.AssetUsages.CreateAssetUsage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsage;

public sealed class CreateAssetUsageCommandValidator
    : AbstractValidator<CreateAssetUsageCommand>
{
    public CreateAssetUsageCommandValidator()
    {
        RuleFor(c => c.StartDate)
            .NotEmpty();

     


    }
}