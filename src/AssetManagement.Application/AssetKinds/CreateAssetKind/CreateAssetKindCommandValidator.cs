using AssetManagement.Application.AssetKinds.CreateAssetKind;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.CreateAssetKind;

public sealed class CreateAssetKindCommandValidator
    : AbstractValidator<CreateAssetKindCommand>
{
    public CreateAssetKindCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

     


    }
}