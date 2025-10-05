using AttributionEngine.AttributionModels;
using AttributionEngine.Data;

namespace AttributionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Investment Attribution Engine v1.0");

            // Load data from JSON
            var loader = new DataLoader();
            var (portfolio, benchmark) = loader.LoadFromJson("Data/sample-data.json");

            // Create engine with Brinson-Fachler model
            IAttributionModel model = new BrinsonFachlerModel();
            var engine = new Engine.AttributionEngine(model);

            // Run analysis
            var result = engine.RunAnalysis(portfolio, benchmark);

            // Output results
            Console.WriteLine($"Portfolio Return: {portfolio.Return:F2}%");
            Console.WriteLine($"Benchmark Return: {benchmark.Return:F2}%");
            Console.WriteLine("Portfolio Holdings:");
            foreach (var holding in portfolio.Holdings)
            {
                Console.WriteLine($"  {holding.AssetName} ({holding.Sector}): {holding.Weight * 100:F2}% @ {holding.Return:F2}%");
            }
            Console.WriteLine("Benchmark Holdings:");
            foreach (var holding in benchmark.Holdings)
            {
                Console.WriteLine($"  {holding.Sector}: {holding.Weight * 100:F2}% @ {holding.Return:F2}%");
            }
            Console.WriteLine("Attribution Results:");
            Console.WriteLine($"  Allocation Effect: {result.AllocationEffect:F2}%");
            Console.WriteLine($"  Selection Effect: {result.SelectionEffect:F2}%");
            Console.WriteLine($"  Total Effect: {(result.AllocationEffect + result.SelectionEffect):F2}%");
        }
    }
}