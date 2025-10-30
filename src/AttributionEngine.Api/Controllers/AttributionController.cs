using Microsoft.AspNetCore.Mvc;

using AttributionEngine.Core.AttributionModels;
using AttributionEngine.Core.Engine;
using AttributionEngine.Core.Models;
using AttributionEngine.Infrastructure.Data;

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
                // Log start
                Console.WriteLine("Running Attribution Engine...");

                // Instantiate DataLoader
                // var loader = new DataLoader();

                // Load data
                // var loader = new DataLoader();
                // var (portfolio, benchmark) = loader.LoadFromJson("Data/sample-data.json");
                // var dataPath = Path.Combine(AppContext.BaseDirectory, "Data", "sample-data.json");
                // var (portfolio, benchmark) = loader.LoadFromJson(dataPath);
                var loader = new DataLoader();
                var (portfolio, benchmark) = loader.LoadFromJson("sample-data.json");

                // Create engine
                IAttributionModel model = new BrinsonFachlerModel();
                var engine = new Core.Engine.AttributionEngine(model);

                // Run analysis
                var result = engine.RunAnalysis(portfolio, benchmark);

                // Prepare response object
                var response = new
                {
                    PortfolioReturn = portfolio.Return,
                    BenchmarkReturn = benchmark.Return,
                    Attribution = new
                    {
                        result.AllocationEffect,
                        result.SelectionEffect,
                        TotalEffect = result.AllocationEffect + result.SelectionEffect
                    },
                    PortfolioHoldings = portfolio.Holdings.Select(h => new
                    {
                        h.AssetName,
                        h.Sector,
                        Weight = h.Weight,
                        h.Return
                    }),
                    BenchmarkHoldings = benchmark.Holdings.Select(h => new
                    {
                        h.AssetName,
                        h.Sector,
                        Weight = h.Weight,
                        h.Return
                    })
                };

                // Return JSON
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
