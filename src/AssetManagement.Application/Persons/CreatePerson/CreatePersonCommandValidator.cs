using AssetManagement.Application.Persons.CreatePerson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.CreatePerson;

public sealed class CreatePersonCommandValidator
    : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

        RuleFor(c => c.EmailAddress)
            .NotEmpty();


    }
}