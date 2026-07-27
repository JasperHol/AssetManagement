using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AgreementStatuses.CreateAgreementStatus;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AgreementStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManagement.Application.AgreementStatuses.CreateAgreementStatus;

internal sealed class CreateAgreementStatusCommandHandler
    : ICommandHandler<CreateAgreementStatusCommand, int>
{
    private readonly IAgreementStatusRepository _modelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAgreementStatusCommandHandler(
        IAgreementStatusRepository modelRepository,
        IUnitOfWork unitOfWork)
    {
        _modelRepository = modelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAgreementStatusCommand request, CancellationToken cancellationToken)
    {
        var model = AgreementStatus.Create(
            new Name(request.Name),
            request.IsStartStatus,
            request.IsStopStatus);

        _modelRepository.Add(model);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(model.Id);
    }
}