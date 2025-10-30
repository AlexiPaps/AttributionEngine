namespace AttributionEngine.Core.Models
{
    public class Benchmark(List<Holding> holdings, double returnValue)
    {
        public IReadOnlyList<Holding> Holdings { get; } = holdings.AsReadOnly();
        public double Return { get; } = returnValue;
    }
}