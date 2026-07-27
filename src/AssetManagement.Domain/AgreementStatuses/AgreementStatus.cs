using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AgreementStatuses.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AgreementStatuses;
public sealed class AgreementStatus : Entity
{

    private AgreementStatus(
         Name name,
         bool isStartStatus,
         bool isStopStatus)
    {
        Name = name;
        IsStartStatus = isStartStatus;
        IsStopStatus = isStopStatus;
    }

    private AgreementStatus()
    {
    }
    public int Id { get; private set; }
    public Name Name { get; private set; }
    public bool IsStartStatus { get; private set; }
    public bool IsStopStatus { get; private set; }

    public static AgreementStatus Create(
       Name name,
       bool isStartStatus,
       bool isStopStatus)

    {
        var agreementStatus = new AgreementStatus(
            name,
            isStartStatus,
            isStopStatus);

        agreementStatus.RaiseDomainEvent(
            new AgreementStatusCreatedDomainEvent(
                agreementStatus.Name,
                isStartStatus,
                isStopStatus));

        return agreementStatus;
    }


}