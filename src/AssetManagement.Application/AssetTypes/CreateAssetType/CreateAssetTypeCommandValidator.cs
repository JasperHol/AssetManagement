using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.CreateAssetType;
public sealed class CreateAssetTypeCommandValidator
    : AbstractValidator<CreateAssetTypeCommand>
{
    public CreateAssetTypeCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

        RuleFor(c => c.Description)
            .NotEmpty();


    }
}
