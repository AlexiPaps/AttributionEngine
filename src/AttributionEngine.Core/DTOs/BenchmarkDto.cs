namespace AttributionEngine.Core.DTOs;

public class BenchmarkDto
{
    public List<HoldingDto> Holdings { get; set; } = new();
    public double Return { get; set; }
}
