using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.UpdateDefaultLocation;

public sealed class UpdateDefaultLocationCommandValidator
    : AbstractValidator<UpdateDefaultLocationCommand>
{
    public UpdateDefaultLocationCommandValidator()
    {
        RuleFor(c => c.Description)
             .NotEmpty();

    }
}