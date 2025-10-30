using AttributionEngine.Core.Models;

namespace AttributionEngine.Core.AttributionModels
{
    public interface IAttributionModel
    {
        AttributionResult CalculateAttribution(Portfolio portfolio, Benchmark benchmark);
    }
}