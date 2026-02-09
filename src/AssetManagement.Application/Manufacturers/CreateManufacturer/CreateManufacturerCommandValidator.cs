using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.CreateManufacturer;
public sealed class CreateManufacturerCommandValidator
    : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

        RuleFor(c => c.Description)
            .NotEmpty();


    }
}
