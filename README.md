# Investment Attribution Engine

A C# console application for calculating investment performance attribution using pluggable models, designed with extensibility and clean architecture in mind. Currently implements the Brinson-Fachler model to compute allocation and selection effects for portfolio performance analysis.

## Features
- **Pluggable Models**: Supports different attribution models via the `IAttributionModel` interface.
- **Brinson-Fachler Model**: Calculates allocation and selection effects based on portfolio and benchmark sector weights and returns.
- **JSON Input**: Loads portfolio and benchmark data from a JSON file.
- **Clean Design**: Uses object-oriented principles for modularity and maintainability.

## Project Structure
```html
AttributionEngine/
├── .git/                           # Git repository
├── AttributionEngine.csproj        # Main project file
├── Program.cs                      # Entry point; runs attribution analysis
├── Models/                         # Domain models
│   ├── Holding.cs                  # Represents an asset holding
│   ├── Portfolio.cs                # Represents a portfolio
│   ├── Benchmark.cs                # Represents a benchmark
│   ├── AttributionResult.cs        # Stores attribution results
├── AttributionModels/              # Attribution model implementations
│   ├── IAttributionModel.cs        # Interface for attribution models
│   ├── BrinsonFachlerModel.cs      # Brinson-Fachler model implementation
├── Engine/                         # Core engine
│   ├── AttributionEngine.cs        # Executes attribution analysis
├── Data/                           # Data files
│   ├── sample-data.json            # Sample portfolio and benchmark data
├── AttributionEngine.sln           # Solution file
```

## Requirements
- .NET 9.0 SDK
- System.Text.Json (included via NuGet)

## Setup
1. Clone the repository:
   ```bash
   git clone <repository-url>
2. Restore dependencies:
   ```bash
   cd AttributionEngine
   dotnet restore
3. Build the project:
   ```bash
   dotnet build
4. Run the application:
   ```bash
   dotnet run

The app loads data from Data/sample-data.json, runs the Brinson-Fachler model, and outputs:Portfolio and benchmark returns
Holdings details
Attribution results (allocation and selection effects)

## Sample Output

```html
Investment Attribution Engine v1.0
Portfolio Return: 7.50%
Benchmark Return: 6.00%
Portfolio Holdings:
  Apple (Tech): 30.00% @ 10.00%
  Microsoft (Tech): 20.00% @ 12.00%
  Exxon (Energy): 50.00% @ 5.00%
Benchmark Holdings:
  Tech: 50.00% @ 8.00%
  Energy: 50.00% @ 4.00%
Attribution Results:
  Allocation Effect: 0.00%
  Selection Effect: 1.90%
  Total Effect: 1.90%
```


