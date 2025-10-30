using AttributionEngine.Core.Models;
using System.Text.Json;

namespace AttributionEngine.Infrastructure.Data
{
    public class DataLoader
    {
        public (Portfolio Portfolio, Benchmark Benchmark) LoadFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<InputData>(json);

            ArgumentNullException.ThrowIfNull(data);

            var portfolioHoldings = new List<Holding>();
            foreach (var h in data.Portfolio.Holdings)
            {
                portfolioHoldings.Add(new(h.AssetName, h.Sector, h.Weight, h.Return));
            }
            var portfolio = new Portfolio(portfolioHoldings, data.Portfolio.Return);

            var benchmarkHoldings = new List<Holding>();
            foreach (var h in data.Benchmark.Holdings)
            {
                benchmarkHoldings.Add(new(h.AssetName, h.Sector, h.Weight, h.Return));
            }
            var benchmark = new Benchmark(benchmarkHoldings, data.Benchmark.Return);

            return (portfolio, benchmark);
        }

        private class InputData
        {
            public required InputPortfolio Portfolio { get; set; }
            public required InputBenchmark Benchmark { get; set; }
        }

        private class InputPortfolio
        {
            public required List<InputHolding> Holdings { get; set; }
            public required double Return { get; set; }
        }

        private class InputBenchmark
        {
            public required List<InputHolding> Holdings { get; set; }
            public required double Return { get; set; }
        }

        private class InputHolding
        {
            public required string AssetName { get; set; }
            public required string Sector { get; set; }
            public required double Weight { get; set; }
            public required double Return { get; set; }
        }
    }
}