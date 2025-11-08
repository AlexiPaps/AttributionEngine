using Microsoft.AspNetCore.Mvc;
using AttributionEngine.Core.AttributionModels;
using AttributionEngine.Infrastructure.Data;
using AttributionEngine.Core.DTOs;

namespace AttributionEngine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributionController : ControllerBase
    {
        [HttpGet("run")]
        public IActionResult RunAttribution()
        {
            try
            {
                Console.WriteLine("Running Attribution Engine...");

                var loader = new DataLoader();
                var (portfolio, benchmark) = loader.LoadFromJson("sample-data.json");

                IAttributionModel model = new BrinsonFachlerModel();
                var engine = new Core.Engine.AttributionEngine(model);

                var result = engine.RunAnalysis(portfolio, benchmark);

                var dto = new AttributionResultDto
                {
                    PortfolioReturn = portfolio.Return,
                    BenchmarkReturn = benchmark.Return,
                    Attribution = new AttributionDto
                    {
                        AllocationEffect = result.AllocationEffect,
                        SelectionEffect = result.SelectionEffect,
                        TotalEffect = result.AllocationEffect + result.SelectionEffect
                    },
                    PortfolioHoldings = portfolio.Holdings.Select(h => new HoldingDto
                    {
                        AssetName = h.AssetName,
                        Sector = h.Sector,
                        Weight = h.Weight,
                        Return = h.Return
                    }).ToList(),
                    BenchmarkHoldings = benchmark.Holdings.Select(h => new HoldingDto
                    {
                        AssetName = h.AssetName,
                        Sector = h.Sector,
                        Weight = h.Weight,
                        Return = h.Return
                    }).ToList()
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
