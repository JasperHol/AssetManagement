using AssetManagement.Application.AssetTypes.UpdateAssetType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.UpdateAssetType;

public sealed class UpdateAssetTypeCommandValidator
    : AbstractValidator<UpdateAssetTypeCommand>
{
    public UpdateAssetTypeCommandValidator()
    {
       // RuleFor(c => c.Requestable)
       //     .NotEmpty();

    }
}
