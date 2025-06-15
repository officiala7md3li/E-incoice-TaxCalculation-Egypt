# Egyptian E-Invoice Tax Calculation Library

## Description

This project is a **Class Library** designed for tax and fee calculations in the **Egyptian E-Invoice System**. It handles **dependent and non-dependent taxes**, VAT, exemptions, and fee structures based on the Egyptian tax regulations. The library provides a modular and extensible way to integrate tax calculations into different systems, ensuring compliance with official tax laws.

## Features

- **Egyptian E-Invoice Tax Calculation**
- **Dependent & Non-Dependent Tax Handling**
- **VAT Calculation with Configurable Rates**
- **Tax Exemptions & Special Cases Processing**
- **Multi-Tiered Tax Structures**
- **Fee Calculation Based on Regulations**
- **Integration with ERP & Financial Systems**
- **Extensible Design for Future Tax Law Updates**

## Technologies Used

- **.NET Core 8 (Class Library)**
- **Unit Testing Support for Accuracy Validation**
- **NuGet Package Integration**

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/officiala7md3li/E-incoice-TaxCalculation-Egypt.git
   ```
2. Navigate to the project directory:
   ```sh
   cd E-incoice-TaxCalculation-Egypt
   ```
3. Install dependencies:
   ```sh
   dotnet restore
   ```
4. Build the library:
   ```sh
   dotnet build
   ```

## Usage

### Quick Example

```csharp
// Define base amount
decimal baseAmount = 100m;

// Create a tax calculation engine builder
var builder = new TaxCalculationEngineBuilder();

// Configure tax strategies
builder.WithStrategy(TaxTypeEnum.VAT, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.VAT, 0.14m));
builder.WithStrategy(TaxTypeEnum.ServiceTax, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.ServiceTax, 0.05m));
builder.WithStrategy(TaxTypeEnum.EntertainmentTax, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.EntertainmentTax, 0.07m));
builder.WithStrategy(TaxTypeEnum.OtherFees, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.OtherFees, 0.10m));

// Build the engine and calculate taxes
TaxCalculationEngine engine = builder.Build();
var computedTaxes = engine.CalculateTaxes(baseAmount);

// Output results
foreach (var tax in computedTaxes)
{
    Console.WriteLine($"{tax.Type}: {tax.Amount}");
}
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a new branch (`feature-branch`)
3. Commit your changes
4. Push to the branch and submit a pull request

## License

This project is licensed under the **MIT License**.

---

Feel free to update the repository URL and add any additional details as needed.
