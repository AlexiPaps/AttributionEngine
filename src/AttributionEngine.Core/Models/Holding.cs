namespace AttributionEngine.Core.Models
{
    public class Holding(string assetName, string sector, double weight, double returnValue)
    {
        public string AssetName { get; } = assetName;
        public string Sector { get; } = sector;
        public double Weight { get; } = weight;
        public double Return { get; } = returnValue;
    }
}