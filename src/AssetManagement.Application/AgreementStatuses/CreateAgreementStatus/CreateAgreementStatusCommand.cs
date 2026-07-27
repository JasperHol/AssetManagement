using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AgreementStatuses.CreateAgreementStatus;
public record CreateAgreementStatusCommand(
    string Name,
    bool IsStartStatus,
    bool IsStopStatus)
    : ICommand<int>;