using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes.Events;
using AssetManagement.Domain.Shared;
//AssetType
namespace AssetManagement.Domain.AssetTypes;

public sealed class AssetType : Entity
{
    private AssetType(
        Name name,
        Description description,
        Requestable requestable,
        DepreciationValue? depreciationValue,
        DepreciationPeriod? depreciationPeriod,
        DataSource? dataSource,
        JiraId? jiraId,
        PrefixName? prefixName,
        SecuritySensitive? securitySensitive,
        MobileEquipment? mobileEquipment,
        ModelId? modelId,
        AssetKindId? assetKindId)
    {
        Name = name;
        Description = description;
        Requestable = requestable;
        DepreciationValue = depreciationValue;
        DepreciationPeriod = depreciationPeriod;
        DataSource = dataSource;
        JiraId = jiraId;
        PrefixName = prefixName;
        SecuritySensitive = securitySensitive;
        MobileEquipment = mobileEquipment;
        ModelId = modelId;
        AssetKindId = assetKindId;
    }

    private AssetType() { }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Requestable Requestable { get; private set; }

    public DepreciationValue? DepreciationValue { get; private set; }
    public DepreciationPeriod? DepreciationPeriod { get; private set; }
    public DataSource? DataSource { get; private set; }
    public JiraId? JiraId { get; private set; }
    public PrefixName? PrefixName { get; private set; }
    public SecuritySensitive? SecuritySensitive { get; private set; }
    public MobileEquipment? MobileEquipment { get; private set; }
    public ModelId? ModelId { get; private set; }
    public AssetKindId? AssetKindId { get; private set; }

    public static AssetType Create(
        Name name,
        Description description,
        Requestable? requestable = null,
        DepreciationValue? depreciationValue = null,
        DepreciationPeriod? depreciationPeriod = null,
        DataSource? dataSource = null,
        JiraId? jiraId = null,
        PrefixName? prefixName = null,
        SecuritySensitive? securitySensitive = null,
        MobileEquipment? mobileEquipment = null,
        ModelId? modelId = null,
        AssetKindId? assetKindId = null)
    {
        var assetType = new AssetType(
            name,
            description,
            requestable ?? Requestable.True,
            depreciationValue,
            depreciationPeriod,
            dataSource,
            jiraId,
            prefixName,
            securitySensitive,
            mobileEquipment,
            modelId,
            assetKindId);

        assetType.RaiseDomainEvent(
            new AssetTypeCreatedDomainEvent(
                assetType.Id,
                assetType.Name,
                assetType.Description,
                assetType.Requestable));

        return assetType;
    }

    public void ToggleRequestable()
    {
        Requestable = Requestable.Toggle();

        RaiseDomainEvent(
            new AssetTypeUpdatedDomainEvent(Id, Requestable));
    }

    public void UpdateDetails(
        Name name,
        Description description)
    {
        Name = name;
        Description = description;

        RaiseDomainEvent(
            new AssetTypeUpdatedDomainEvent(Id, Requestable));
    }

    public void UpdateDepreciation(
        DepreciationValue? value,
        DepreciationPeriod? period)
    {
        DepreciationValue = value;
        DepreciationPeriod = period;

        RaiseDomainEvent(
            new AssetTypeUpdatedDomainEvent(Id, Requestable));
    }

    public void UpdateMetadata(
        DataSource? dataSource,
        JiraId? jiraId,
        PrefixName? prefixName,
        SecuritySensitive? securitySensitive,
        MobileEquipment? mobileEquipment,
        ModelId? modelId,
        AssetKindId? assetKindId)
    {
        DataSource = dataSource;
        JiraId = jiraId;
        PrefixName = prefixName;
        SecuritySensitive = securitySensitive;
        MobileEquipment = mobileEquipment;
        ModelId = modelId;
        AssetKindId = assetKindId;

        RaiseDomainEvent(
            new AssetTypeUpdatedDomainEvent(Id, Requestable));
    }
}