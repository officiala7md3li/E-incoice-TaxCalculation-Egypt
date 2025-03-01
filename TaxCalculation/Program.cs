// See https://aka.ms/new-console-template for more information
using TaxCalculation;
using TaxCalculation.Enums;
using TaxCalculation.Factories;
using TaxCalculation.Services;

Console.WriteLine("Hello, World!");
decimal baseAmount = 100m;
var builder = new TaxCalculationEngineBuilder();

// Example: Configure a few taxes.
builder.WithStrategy(TaxTypeEnum.V009, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.V009, 0.14m));

builder.WithStrategy(TaxTypeEnum.Tbl01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Tbl01, 0.05m));

builder.WithStrategy(TaxTypeEnum.Tbl02, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Tbl02, 10m));

builder.WithStrategy(TaxTypeEnum.W001, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.W001, 0.01m));

builder.WithStrategy(TaxTypeEnum.ST01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.ST01, 0.05m));

builder.WithStrategy(TaxTypeEnum.ST02, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.ST02, 6m));

builder.WithStrategy(TaxTypeEnum.Ent01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Ent01, 0.07m));

builder.WithStrategy(TaxTypeEnum.RD01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.RD01, 0.08m));

builder.WithStrategy(TaxTypeEnum.SC01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.SC01, 0.09m));

builder.WithStrategy(TaxTypeEnum.Mn01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Mn01, 0.10m));

builder.WithStrategy(TaxTypeEnum.MI01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.MI01, 0.11m));

builder.WithStrategy(TaxTypeEnum.OF01, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.OF01, 0.12m));

builder.WithStrategy(TaxTypeEnum.ST03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.ST03, 0.13m));

builder.WithStrategy(TaxTypeEnum.ST04, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.ST04, 14m));

builder.WithStrategy(TaxTypeEnum.Ent03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Ent03, 0.15m));

builder.WithStrategy(TaxTypeEnum.RD03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.RD03, 0.16m));

builder.WithStrategy(TaxTypeEnum.SC03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.SC03, 0.17m));

builder.WithStrategy(TaxTypeEnum.Mn03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.Mn03, 0.18m));

builder.WithStrategy(TaxTypeEnum.MI03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.MI03, 0.19m));

builder.WithStrategy(TaxTypeEnum.OF03, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.OF03, 0.20m));



TaxCalculationEngine engine = builder.Build();
var computedTaxes = engine.CalculateTaxes(baseAmount);

Console.WriteLine($"Base Amount: {baseAmount:C}");
//foreach (var kvp in computedTaxes)
//{
//    Console.WriteLine($"{kvp.Key}: {kvp.Value:C}");
//}


//var categorizedTaxes = computedTaxes
//                .Select(ct =>
//                {
//                    // Convert the enum value to a string to match the metadata Code.
//                    string taxCode = ct.Key.ToString();
//                    // Get the corresponding metadata
//                    var metadata = TaxMetadataRepository.GetByCode(taxCode);
//                    return new
//                    {
//                        Code = taxCode,
//                        Amount = ct.Value,
//                        TaxtypeReference = metadata?.TaxtypeReference ?? "Unknown",
//                        Description = metadata?.Desc_en ?? "No Description"
//                    };
//                })
//                .GroupBy(x => x.TaxtypeReference)
//                .Select(g => new
//                {
//                    TaxtypeReference = g.Key,
//                    TotalAmount = g.Sum(x => x.Amount),
//                    Details = g.ToList()
//                })
//                .ToList();
// Calculate and retrieve the categorized taxes as a List<TaxesCategoriezed>.
var categorizedTaxes = TaxCategorizer.GetCategorizedTaxes(baseAmount, engine);

// Example 1: Simply list each tax with its details.
//Console.WriteLine("=== Categorized Taxes ===");
//foreach (var tax in categorizedTaxes)
//{
//    Console.WriteLine($"Tax Code: {tax.TaxTypeEnum}, Category: {tax.TaxtypeReference}, Desc (EN): {tax.EnglisghDescription}");
//}

// Example 2: Group the taxes by their category (TaxtypeReference).
Console.WriteLine("\n=== Taxes Grouped by Category ===");
var groupedTaxes = categorizedTaxes.OrderBy(x=>x.TaxtypeReference).GroupBy(x => x.TaxtypeReference);
//foreach (var group in groupedTaxes)
//{
//    Console.WriteLine($"Category: {group.Key}");
//    foreach (var tax in group)
//    {
//        Console.WriteLine($"\tTax Code: {tax.TaxTypeEnum}, Desc (EN): {tax.EnglisghDescription}");
//    }
//}
// Display the results
foreach (var group in groupedTaxes)
{
    Console.WriteLine($"Tax Category (TaxtypeReference): {group.Key}");
    Console.WriteLine($"  Total Amount: {group.Sum(x=>x.Amount):C}");
    foreach (var tax in group)
    {
        Console.WriteLine($"    {tax.TaxTypeEnum.ToString()} ({tax.EnglisghDescription}): {tax.Amount:C}");
    }
    Console.WriteLine();
}
decimal finalTotal = baseAmount + computedTaxes.Values.Sum();
Console.WriteLine($"Final Total Amount: {finalTotal:C}");