using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.UpdateModel;

public sealed class UpdateModelCommandValidator
    : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator()
    {
        // RuleFor(c => c.Requestable)
        //     .NotEmpty();

    }
}