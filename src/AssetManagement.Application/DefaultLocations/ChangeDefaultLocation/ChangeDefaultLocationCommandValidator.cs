
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.ChangeDefaultLocation;

public sealed class ChangeDefaultLocationCommandValidator
    : AbstractValidator<ChangeDefaultLocationCommand>
{
    public ChangeDefaultLocationCommandValidator()
    {
        RuleFor(c => c.LocationId)
             .NotEmpty();

    }
}