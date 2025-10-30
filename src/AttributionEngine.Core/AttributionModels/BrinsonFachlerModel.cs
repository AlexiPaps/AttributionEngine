using AttributionEngine.Core.Models;

namespace AttributionEngine.Core.AttributionModels
{
    public class BrinsonFachlerModel : IAttributionModel
    {
        public AttributionResult CalculateAttribution(Portfolio portfolio, Benchmark benchmark)
        {
            double allocationEffect = 0.0;
            double selectionEffect = 0.0;

            // Group portfolio holdings by sector
            var portfolioBySector = portfolio.Holdings
                .GroupBy(h => h.Sector)
                .Select(g => new
                {
                    Sector = g.Key,
                    Weight = g.Sum(h => h.Weight),
                    Return = g.Sum(h => h.Weight * h.Return) / g.Sum(h => h.Weight)
                });

            // Calculate effects for each sector
            foreach (var sector in portfolioBySector)
            {
                var benchHolding = benchmark.Holdings.FirstOrDefault(h => h.Sector == sector.Sector);
                if (benchHolding != null)
                {
                    // Allocation effect: (Portfolio weight - Benchmark weight) * Benchmark return
                    allocationEffect += (sector.Weight - benchHolding.Weight) * benchHolding.Return;

                    // Selection effect: Portfolio weight * (Portfolio return - Benchmark return)
                    selectionEffect += sector.Weight * (sector.Return - benchHolding.Return);
                }
            }

            return new AttributionResult(allocationEffect, selectionEffect);
        }
    }
}