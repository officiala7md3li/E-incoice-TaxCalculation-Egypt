using TaxCalculation.Enums;
using TaxCalculation.Factories;
using TaxCalculation.Services;

public class TaxCalculationEngineTests
{
    public static IEnumerable<object[]> GetTestCases()
    {
        // Test 1 – all taxes, base = 100
        // Expected computed individual taxes (as provided):
        // T1: V009 = 26.096, T2: Tbl01 = 8.400, T3: Tbl02 = 10.000,
        // T4: W001 = -1.000, T5: ST01 = 5.000, T6: ST02 = 6.000,
        // T7: Ent01 = 7.000, T8: RD01 = 8.000, T9: SC01 = 9.000,
        // T10: Mn01 = 10.000, T11: MI01 = 11.000, T12: OF01 = 12.000,
        // T13: ST03 = 13.000, T14: ST04 = 14.000, T15: Ent03 = 15.000,
        // T16: RD03 = 16.000, T17: SC03 = 17.000, T18: Mn03 = 18.000,
        // T19: MI03 = 19.000, T20: OF03 = 20.000
        // Final total = Base (100) + sum(all computed taxes)
        decimal expectedTotalTest1 = 343.496m;
        yield return new object[]
        {
                100m,
                new List<TaxTypeEnum>
                {
                    TaxTypeEnum.V009, TaxTypeEnum.Tbl01, TaxTypeEnum.Tbl02,
                    TaxTypeEnum.W001, TaxTypeEnum.ST01, TaxTypeEnum.ST02,
                    TaxTypeEnum.Ent01, TaxTypeEnum.RD01, TaxTypeEnum.SC01,
                    TaxTypeEnum.Mn01, TaxTypeEnum.MI01, TaxTypeEnum.OF01,
                    TaxTypeEnum.ST03, TaxTypeEnum.ST04, TaxTypeEnum.Ent03,
                    TaxTypeEnum.RD03, TaxTypeEnum.SC03, TaxTypeEnum.Mn03,
                    TaxTypeEnum.MI03, TaxTypeEnum.OF03
                },
                new List<decimal>
                {
                    0.14m,  // V009
                    0.05m,  // Tbl01
                    10.00m, // Tbl02 (fixed)
                    0.01m,  // W001 (deduction)
                    0.05m,  // ST01
                    6.00m,  // ST02 (fixed)
                    0.07m,  // Ent01
                    0.08m,  // RD01
                    0.09m,  // SC01
                    0.10m,  // Mn01
                    0.11m,  // MI01
                    0.12m,  // OF01
                    0.13m,  // ST03
                    14.00m, // ST04 (fixed)
                    0.15m,  // Ent03
                    0.16m,  // RD03
                    0.17m,  // SC03
                    0.18m,  // Mn03
                    0.19m,  // MI03
                    0.20m   // OF03
                },
                expectedTotalTest1
        };

        // Test 2 – base = 100; expected final total = 1,278.60
        decimal expectedTotalTest2 = 1278.60m;
        yield return new object[]
        {
                100m,
                new List<TaxTypeEnum>
                {
                    TaxTypeEnum.V009, TaxTypeEnum.Tbl01, TaxTypeEnum.Tbl02,
                    TaxTypeEnum.W001, TaxTypeEnum.ST01, TaxTypeEnum.ST02,
                    TaxTypeEnum.Ent01, TaxTypeEnum.RD01, TaxTypeEnum.SC01,
                    TaxTypeEnum.Mn01, TaxTypeEnum.MI01, TaxTypeEnum.OF01,
                    TaxTypeEnum.ST03, TaxTypeEnum.ST04, TaxTypeEnum.Ent03,
                    TaxTypeEnum.RD03, TaxTypeEnum.SC03, TaxTypeEnum.Mn03,
                    TaxTypeEnum.MI03, TaxTypeEnum.OF03
                },
                new List<decimal>
                {
                    0.10m,  // V009
                    0.20m,  // Tbl01
                    30.00m, // Tbl02
                    0.40m,  // W001 (deduction)
                    0.50m,  // ST01
                    60.00m, // ST02
                    0.70m,  // Ent01
                    0.80m,  // RD01
                    0.90m,  // SC01
                    1.00m,  // Mn01
                    0.10m,  // MI01
                    0.20m,  // OF01
                    0.30m,  // ST03
                    40.00m, // ST04
                    0.50m,  // Ent03
                    0.60m,  // RD03
                    0.70m,  // SC03
                    0.80m,  // Mn03
                    0.90m,  // MI03
                    1.00m   // OF03
                },
                expectedTotalTest2
        };

        // Test 3 – base = 100; expected final total = 1,071.35
        decimal expectedTotalTest3 = 1071.35m;
        yield return new object[]
        {
                100m,
                // Note: In Test 3 the order is slightly different; notice Tbl02 is placed at the end.
                new List<TaxTypeEnum>
                {
                    TaxTypeEnum.V009, TaxTypeEnum.Tbl01, // T1 and T2
                    TaxTypeEnum.W001, TaxTypeEnum.ST01, TaxTypeEnum.ST02,
                    TaxTypeEnum.Ent01, TaxTypeEnum.RD01, TaxTypeEnum.SC01,
                    TaxTypeEnum.Mn01, TaxTypeEnum.MI01, TaxTypeEnum.OF01,
                    TaxTypeEnum.ST03, TaxTypeEnum.ST04, TaxTypeEnum.Ent03,
                    TaxTypeEnum.RD03, TaxTypeEnum.SC03, TaxTypeEnum.Mn03,
                    TaxTypeEnum.MI03, TaxTypeEnum.OF03,
                    TaxTypeEnum.Tbl02 // T3 (Fixed Amount) moved here
                },
                new List<decimal>
                {
                    0.15m,  // V009
                    0.20m,  // Tbl01
                    0.30m,  // W001 (deduction)
                    0.35m,  // ST01
                    40.00m, // ST02
                    0.45m,  // Ent01
                    0.50m,  // RD01
                    0.55m,  // SC01
                    0.60m,  // Mn01
                    0.65m,  // MI01
                    0.70m,  // OF01
                    0.65m,  // ST03
                    60.00m, // ST04
                    0.55m,  // Ent03
                    0.45m,  // RD03
                    0.40m,  // SC03
                    0.35m,  // Mn03
                    0.30m,  // MI03
                    0.25m,  // OF03
                    25.00m  // Tbl02 (fixed)
                },
                expectedTotalTest3
        };
        // Test 4: Detailed case with 20 tax types (T1, T2, T4-T20, and T3 at the end)
        // Base amount: 100
        // Expected final total: 840.7424
        yield return new object[]
        {
                100m,
                new List<TaxTypeEnum>
                {
                    TaxTypeEnum.V009,   // T1: Value added Tax
                    TaxTypeEnum.Tbl01,  // T2: Table tax (percentage)
                    TaxTypeEnum.W001,   // T4: Withholding Tax (deduction)
                    TaxTypeEnum.ST01,   // T5: Stamping Tax (percentage)
                    TaxTypeEnum.ST02,   // T6: Stamping Tax (fixed)
                    TaxTypeEnum.Ent01,  // T7: Entertainment Tax
                    TaxTypeEnum.RD01,   // T8: Resource development fee
                    TaxTypeEnum.SC01,   // T9: Service Charges
                    TaxTypeEnum.Mn01,   // T10: Municipality Fees
                    TaxTypeEnum.MI01,   // T11: Medical Insurance fee
                    TaxTypeEnum.OF01,   // T12: Other fees
                    TaxTypeEnum.ST03,   // T13: Stamping Tax (percentage)
                    TaxTypeEnum.ST04,   // T14: Stamping Tax (fixed)
                    TaxTypeEnum.Ent03,  // T15: Entertainment Tax
                    TaxTypeEnum.RD03,   // T16: Resource development fee
                    TaxTypeEnum.SC03,   // T17: Service Charges
                    TaxTypeEnum.Mn03,   // T18: Municipality Fees
                    TaxTypeEnum.MI03,   // T19: Medical Insurance fee
                    TaxTypeEnum.OF03,   // T20: Other fees
                    TaxTypeEnum.Tbl02   // T3: Table tax (fixed)
                },
                new List<decimal>
                {
                    0.26m,     // V009: 26.00%
                    0.26m,     // Tbl01: 26.00%
                    0.21m,     // W001: 21.00% (deduction)
                    0.12m,     // ST01: 12.00%
                    12.0000m,  // ST02: fixed 12.0000
                    0.29m,     // Ent01: 29.00%
                    0.38m,     // RD01: 38.00%
                    0.33m,     // SC01: 33.00%
                    0.21m,     // Mn01: 21.00%
                    0.26m,     // MI01: 26.00%
                    0.53m,     // OF01: 53.00%
                    0.12m,     // ST03: 12.00%
                    66.0000m,  // ST04: fixed 66.0000
                    0.42m,     // Ent03: 42.00%
                    0.26m,     // RD03: 26.00%
                    0.13m,     // SC03: 13.00%
                    0.26m,     // Mn03: 26.00%
                    0.74m,     // MI03: 74.00%
                    0.43m,     // OF03: 43.00%
                    36.0000m   // Tbl02: fixed 36.0000
                },
                840.7424m
        };
    }

    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void TestTaxCalculation(decimal baseAmount, List<TaxTypeEnum> taxTypes, List<decimal> taxValues, decimal expectedTotal)
    {
        // Arrange: Build the engine with the provided strategies.
        var builder = new TaxCalculationEngineBuilder();
        for (int i = 0; i < taxTypes.Count; i++)
        {
            builder.WithStrategy(taxTypes[i], TaxStrategyFactory.CreateStrategy(taxTypes[i], taxValues[i]));
        }
        TaxCalculationEngine engine = builder.Build();

        // Act: Calculate taxes.
        var computedTaxes = engine.CalculateTaxes(baseAmount);

        // Sum up the computed taxes for the given tax types (ignore any not provided).
        decimal computedTotal = baseAmount;
        foreach (var taxType in taxTypes)
        {
            if (computedTaxes.TryGetValue(taxType, out decimal taxValue))
            {
                computedTotal += taxValue;
            }
        }

        // Assert: The final total should match the expected total (with a tolerance for rounding).
        Assert.Equal(expectedTotal, computedTotal, 3);
    }
}