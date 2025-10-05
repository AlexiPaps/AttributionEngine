using AttributionEngine.Models;

namespace AttributionEngine.AttributionModels
{
    public interface IAttributionModel
    {
        AttributionResult CalculateAttribution(Portfolio portfolio, Benchmark benchmark);
    }
}