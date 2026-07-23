using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.UpdateLocation;

public sealed class UpdateLocationCommandValidator
    : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        // RuleFor(c => c.Requestable)
        //     .NotEmpty();

    }
}