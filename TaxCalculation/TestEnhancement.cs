using System;
using TaxCalculation.Enums;
using TaxCalculation.Services;

namespace TaxCalculation
{
    /// <summary>
    /// Simple test class to demonstrate the enhanced builder pattern
    /// </summary>
    public class TestEnhancement
    {
        public static void RunTest()
        {
            Console.WriteLine("=== Testing Enhanced Builder Pattern ===");
            
            decimal baseAmount = 100m;
            var builder = new TaxCalculationEngineBuilder();
            
            // OLD WAY (still supported for backward compatibility):
            // builder.WithStrategy(TaxTypeEnum.V009, TaxStrategyFactory.CreateStrategy(TaxTypeEnum.V009, 0.14m));
            
            // NEW ENHANCED WAY (simplified syntax):
            builder.WithStrategy(TaxTypeEnum.V009, 0.14m)
                   .WithStrategy(TaxTypeEnum.Tbl01, 0.05m)
                   .WithStrategy(TaxTypeEnum.W001, 0.01m);
            
            var engine = builder.Build();
            var computedTaxes = engine.CalculateTaxes(baseAmount);
            
            Console.WriteLine($"Base Amount: {baseAmount:C}");
            Console.WriteLine("Computed Taxes:");
            foreach (var kvp in computedTaxes)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value:C}");
            }
            
            decimal total = baseAmount + computedTaxes.Values.Sum();
            Console.WriteLine($"Total Amount: {total:C}");
            Console.WriteLine("=== Test Completed Successfully ===");
        }
    }
}
