using AssetManagement.Application.Assets.UpdateAssetStatus;
using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetStatuss.UpdateAssetStatus;

public sealed class UpdateAssetStatusCommandValidator
    : AbstractValidator<UpdateAssetStatusCommand>
{
    public UpdateAssetStatusCommandValidator()
    {
        // RuleFor(c => c.Requestable)
        //     .NotEmpty();

    }
}