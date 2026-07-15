using AssetManagement.Application.AssetKinds.CreateAssetKind;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.CreateAsset;

public sealed class CreateAssetCommandValidator
    : AbstractValidator<CreateAssetCommand>
{
    public CreateAssetCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

        RuleFor(c => c.Brand)
            .NotEmpty();

        RuleFor(c => c.Model)
            .NotEmpty();

        RuleFor(c => c.SerialNumber)
            .NotEmpty();



    }
}