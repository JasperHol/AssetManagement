using AssetManagement.Application.AssetUsages.SignAssetUsage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SignAssetUsage;

public sealed class SignAssetUsageCommandValidator
    : AbstractValidator<SignAssetUsageCommand>
{
    public SignAssetUsageCommandValidator()
    {
       // RuleFor(c => c.Requestable)
       //     .NotEmpty();

    }
}
