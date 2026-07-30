namespace AssetManagement.Api.Controllers.Assets
{
    /// <summary>
    /// Asset status selection.
    /// </summary>
    public enum StatusId
    {
        /// <summary>
        /// 1 - CreateAsset
        /// </summary>
        CreateAsset = 1,

        /// <summary>
        /// 2 - Stock
        /// </summary>
        Stock = 2,

        /// <summary>
        /// 3 - InUse
        /// </summary>
        InUse = 3,

        /// <summary>
        /// 4 - AssetInServiceRepair
        /// </summary>
        AssetInServiceRepair = 4,

        /// <summary>
        /// 5 - ReportedStolenMissing
        /// </summary>
        ReportedStolenMissing = 5,

        /// <summary>
        /// 6 - ObsoleteAsset
        /// </summary>
        ObsoleteAsset = 6,

        /// <summary>
        /// 7 - AssetDisposed
        /// </summary>
        AssetDisposed = 7,

        /// <summary>
        /// 8 - AssetLost
        /// </summary>
        AssetLost = 8
    }
}
