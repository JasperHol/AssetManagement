using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Persons.CreatePerson;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.CreatePerson;

internal sealed class CreatePersonCommandHandler
    : ICommandHandler<CreatePersonCommand, int>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = Person.Create(
            new Name(request.Name),
            new Requestable(request.Requestable),
            new EmailAddress(request.EmailAddress),
            new EmloyeeNumber(request.EmloyeeNumber),
            new DataSource(request.DataSource),
            new Sid(request.Sid),
            new AccountName(request.AccountName),
            request.WorksForId);

        _personRepository.Add(person);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(person.Id);
    }
}