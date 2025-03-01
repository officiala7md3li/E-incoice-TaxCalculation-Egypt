using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;
using TaxCalculation.Strategies;

namespace TaxCalculation.Factories
{
    // Infrastructure Layer - Factory (Infrastructure/Factories/TaxStrategyFactory.cs)
    // 4. Infrastructure Layer – Factory that maps tax codes to strategies
    public static class TaxStrategyFactory
    {
        public static ITaxCalculationStrategy CreateStrategy(TaxTypeEnum taxType, decimal value)
        {
            // For fixed‐amount taxes:
            switch (taxType)
            {
                case TaxTypeEnum.Tbl02:
                case TaxTypeEnum.ST02:
                case TaxTypeEnum.ST04:
                case TaxTypeEnum.Ent02:
                case TaxTypeEnum.RD02:
                case TaxTypeEnum.SC02:
                case TaxTypeEnum.Mn02:
                case TaxTypeEnum.MI02:
                case TaxTypeEnum.OF02:
                case TaxTypeEnum.Ent04:
                case TaxTypeEnum.RD04:
                case TaxTypeEnum.SC04:
                case TaxTypeEnum.Mn04:
                case TaxTypeEnum.MI04:
                case TaxTypeEnum.OF04:
                    return new FixedTaxStrategy(value);

                // For deduction taxes (W-codes):
                case TaxTypeEnum.W001:
                case TaxTypeEnum.W002:
                case TaxTypeEnum.W003:
                case TaxTypeEnum.W004:
                case TaxTypeEnum.W005:
                case TaxTypeEnum.W006:
                case TaxTypeEnum.W007:
                case TaxTypeEnum.W008:
                case TaxTypeEnum.W009:
                case TaxTypeEnum.W010:
                case TaxTypeEnum.W011:
                case TaxTypeEnum.W012:
                case TaxTypeEnum.W013:
                case TaxTypeEnum.W014:
                case TaxTypeEnum.W015:
                case TaxTypeEnum.W016:
                    return new RatioTaxStrategy(value, isDeduction: true);

                // For composite tax Tbl01 – effective base includes dependencies.
                // Modified: exclude ST03.
                case TaxTypeEnum.Tbl01:
                    return new RatioTaxStrategy(value, dependencies: new[]
                    {
                    TaxTypeEnum.ST01,
                    TaxTypeEnum.ST02,
                    TaxTypeEnum.Ent01,
                    TaxTypeEnum.RD01,
                    TaxTypeEnum.SC01,
                    TaxTypeEnum.Mn01,
                    TaxTypeEnum.MI01,
                    TaxTypeEnum.OF01
                    // Exclude TaxTypeEnum.ST03 intentionally.
                });

                // For composite tax Vxxx – effective base includes Tbl01, Tbl02 and sub‐taxes.
                // Modified: exclude ST03.
                case TaxTypeEnum.V001:
                case TaxTypeEnum.V002:
                case TaxTypeEnum.V003:
                case TaxTypeEnum.V004:
                case TaxTypeEnum.V005:
                case TaxTypeEnum.V006:
                case TaxTypeEnum.V007:
                case TaxTypeEnum.V008:
                case TaxTypeEnum.V009:
                case TaxTypeEnum.V010:
                    return new RatioTaxStrategy(value, dependencies: new[]
                    {
                    TaxTypeEnum.Tbl01,
                    TaxTypeEnum.Tbl02,
                    TaxTypeEnum.ST01,
                    TaxTypeEnum.ST02,
                    TaxTypeEnum.Ent01,
                    TaxTypeEnum.RD01,
                    TaxTypeEnum.SC01,
                    TaxTypeEnum.Mn01,
                    TaxTypeEnum.MI01,
                    TaxTypeEnum.OF01
                    // Exclude ST03 here as well.
                });

                // For all other tax codes, return a ratio strategy without dependencies.
                default:
                    return new RatioTaxStrategy(value);
            }
        }
    }
}
