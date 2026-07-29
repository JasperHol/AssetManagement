using AssetManagement.Application.DefaultLocations.CreateDefaultLocation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.CreateDefaultLocation;

public sealed class CreateDefaultLocationCommandValidator
    : AbstractValidator<CreateDefaultLocationCommand>
{
    public CreateDefaultLocationCommandValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty();




    }
}