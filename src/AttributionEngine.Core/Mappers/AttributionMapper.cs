using AttributionEngine.Core.DTOs;
using AttributionEngine.Core.Models;

namespace AttributionEngine.Core.Mappers;

public static class AttributionMapper
{
    public static AttributionResultDto ToDto(Portfolio portfolio, Benchmark benchmark, AttributionResult attribution)
    {
        return new AttributionResultDto
        {
            PortfolioReturn = portfolio.Return,
            BenchmarkReturn = benchmark.Return,
            Attribution = new AttributionDto
            {
                AllocationEffect = attribution.AllocationEffect,
                SelectionEffect = attribution.SelectionEffect,
                TotalEffect = attribution.AllocationEffect + attribution.SelectionEffect
            },
            PortfolioHoldings = portfolio.Holdings
                .Select(ToDto)
                .ToList(),
            BenchmarkHoldings = benchmark.Holdings
                .Select(ToDto)
                .ToList()
        };
    }

    public static HoldingDto ToDto(Holding holding) =>
        new()
        {
            AssetName = holding.AssetName,
            Sector = holding.Sector,
            Weight = holding.Weight,
            Return = holding.Return
        };
}
