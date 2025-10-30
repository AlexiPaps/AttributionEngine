# AttributionEngine

AttributionEngine is a modular .NET 9 application for analyzing and visualizing investment performance attribution.
It separates concerns into clean layers — Core, Infrastructure, API, and Blazor frontend — to ensure scalability and maintainability.

#### 🧠 Features

- Modular architecture (Core, Infrastructure, API, Blazor)

- Portfolio vs. benchmark attribution analysis

- Clean API for attribution results

- Interactive Blazor WebAssembly UI with charts and tables

#### 🧩 Tech Stack

- Backend: ASP.NET Core Web API (.NET 9)

- Frontend: Blazor WebAssembly + MudBlazor + ChartJs.Blazor

- Language: C#

- Data: JSON input (extensible to APIs or databases)

#### 🚀 Getting Started

1️⃣ **Run the API**:

```bash
cd src/AttributionEngine.Api
dotnet run
```

2️⃣ **Run the Blazor frontend:**:
```bash
cd src/AttributionEngine.Blazor
dotnet run
```

3️⃣ **Open the app in your browser and explore the attribution data and charts.**: