using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Persons.UpdatePerson;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRequestable = AssetManagement.Domain.Persons.Requestable;

namespace AssetManagement.Application.Persons.UpdatePerson;

internal sealed class UpdatePersonCommandHandler
    : ICommandHandler<UpdatePersonCommand, int>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
    UpdatePersonCommand request,
    CancellationToken cancellationToken)
    {
        var person = await _personRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (person is null)
        {
            return Result.Failure<int>(
                Error.NotFound(
                    "Person.NotFound",
                    $"Person with id {request.Id} was not found"));
        }

        //person.ToggleRequestable();
        DomainRequestable requestable = new(request.Requestable);
        person.ChangeRequestable(requestable);

        // Optional: only needed if entity is detached
        //_personRepository.Update(person);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(person.Id);
    }
}