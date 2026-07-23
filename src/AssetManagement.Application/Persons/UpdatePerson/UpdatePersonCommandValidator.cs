using AssetManagement.Application.Manufacturers.UpdateManufacturer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.UpdatePerson;

public sealed class UpdatePersonCommandValidator
    : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        // RuleFor(c => c.Requestable)
        //     .NotEmpty();

    }
}