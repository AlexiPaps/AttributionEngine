using AttributionEngine.Core.AttributionModels;
using AttributionEngine.Core.Models;

namespace AttributionEngine.Core.Engine
{
    public class AttributionEngine(IAttributionModel model)
    {
        private readonly IAttributionModel _model = model ?? throw new ArgumentNullException(nameof(model));

        public AttributionResult RunAnalysis(Portfolio portfolio, Benchmark benchmark)
        {
            // Basic input validation
            ArgumentNullException.ThrowIfNull(portfolio);
            ArgumentNullException.ThrowIfNull(benchmark);
            if (portfolio.Holdings == null || portfolio.Holdings.Count == 0)
                throw new ArgumentException("Portfolio holdings cannot be empty.");
            if (benchmark.Holdings == null || benchmark.Holdings.Count == 0)
                throw new ArgumentException("Benchmark holdings cannot be empty.");

            // Delegate to the model
            return _model.CalculateAttribution(portfolio, benchmark);
        }
    }
}