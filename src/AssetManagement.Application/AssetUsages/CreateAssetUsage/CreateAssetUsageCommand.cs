using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.AssetUsages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsage;
public record CreateAssetUsageCommand(
    DateTime StartDate,
    DateTime EndDate,
    string DataSource,
    int AgreementStatus,
    DateTime AgreemnentSignDate,
    DateTime AgreementDeclineDate,
    string AgreementDeclineReason,
    string AgreementUsageAgreementImage,
    int AssetId,
    int PersonId,
    int PersonAssetUsageId,
    int LocationId,
    int AgreementStatusId)    : ICommand<int>;