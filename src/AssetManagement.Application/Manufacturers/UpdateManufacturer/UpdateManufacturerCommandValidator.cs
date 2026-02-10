using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.UpdateManufacturer;

public sealed class UpdateManufacturerCommandValidator
    : AbstractValidator<UpdateManufacturerCommand>
{
    public UpdateManufacturerCommandValidator()
    {
       // RuleFor(c => c.Requestable)
       //     .NotEmpty();

    }
}
