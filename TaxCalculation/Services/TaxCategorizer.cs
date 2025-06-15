using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Infrastructure.Helpers;

namespace TaxCalculation.Services
{
    public static class TaxCategorizer
    {
        public static List<TaxesCategoriezed> GetCategorizedTaxes(decimal baseAmount, TaxCalculationEngine engine)
        {
            // Calculate the taxes using your engine
            var computedTaxes = engine.CalculateTaxes(baseAmount);
            
            // Pre-allocate the result list with known capacity
            var categorizedTaxes = new List<TaxesCategoriezed>(computedTaxes.Count);
            
            // Use a more efficient approach with foreach instead of LINQ
            foreach (var ct in computedTaxes)
            {
                string taxCode = ct.Key.ToString();
                var metadata = TaxMetadataRepository.GetByCode(taxCode);
                
                categorizedTaxes.Add(new TaxesCategoriezed
                {
                    TaxtypeReference = ct.Key.GetTaxTypeGroup(),
                    TaxTypeEnum = ct.Key,
                    EnglisghDescription = metadata?.Desc_en ?? "No description",
                    ArabicDescription = metadata?.Desc_ar ?? "No description",
                    Amount = ct.Value,
                });
            }
            
            return categorizedTaxes;
        }
    }
}
