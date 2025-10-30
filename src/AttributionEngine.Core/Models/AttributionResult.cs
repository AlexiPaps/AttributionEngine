namespace AttributionEngine.Core.Models
{
    public class AttributionResult(double allocationEffect, double selectionEffect)
    {
        public double AllocationEffect { get; } = allocationEffect;
        public double SelectionEffect { get; } = selectionEffect;
    }
}