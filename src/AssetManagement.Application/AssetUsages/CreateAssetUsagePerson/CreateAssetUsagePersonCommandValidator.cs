
using AssetManagement.Application.AssetUsages.CreateAssetUsagePerson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsagePersons.CreateAssetUsagePerson;

public sealed class CreateAssetUsagePersonCommandValidator
    : AbstractValidator<CreateAssetUsagePersonCommand>
{
    public CreateAssetUsagePersonCommandValidator()
    {
        //RuleFor(c => c.StartDate)
        //    .NotEmpty();

     


    }
}