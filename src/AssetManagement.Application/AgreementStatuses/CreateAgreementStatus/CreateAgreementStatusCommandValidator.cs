using AssetManagement.Application.AgreementStatuses.CreateAgreementStatus;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AgreementStatuss.CreateAgreementStatus;

public sealed class CreateAgreementStatusCommandValidator
    : AbstractValidator<CreateAgreementStatusCommand>
{
    public CreateAgreementStatusCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();

    


    }
}