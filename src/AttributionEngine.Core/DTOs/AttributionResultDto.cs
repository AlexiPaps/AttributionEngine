namespace AttributionEngine.Core.DTOs;

public class AttributionResultDto
{
    public double PortfolioReturn { get; set; }
    public double BenchmarkReturn { get; set; }
    public AttributionDto Attribution { get; set; } = new();
    public List<HoldingDto> PortfolioHoldings { get; set; } = new();
    public List<HoldingDto> BenchmarkHoldings { get; set; } = new();
}
