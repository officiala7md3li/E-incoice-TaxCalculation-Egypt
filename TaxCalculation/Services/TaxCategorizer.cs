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

            // For each computed tax, retrieve its static metadata and determine its group.
            var categorizedTaxes = computedTaxes.Select(ct =>
            {
                // Convert the enum to a string (to match the repository's Code property)
                string taxCode = ct.Key.ToString();

                // Retrieve the corresponding metadata from the static repository
                var metadata = TaxMetadataRepository.GetByCode(taxCode);

                return new TaxesCategoriezed
                {
                    // Use the extension method to get the TaxTypeGroup
                    TaxtypeReference = ct.Key.GetTaxTypeGroup(),
                    TaxTypeEnum = ct.Key,
                    EnglisghDescription = metadata?.Desc_en ?? "No description",
                    ArabicDescription = metadata?.Desc_ar ?? "No description",
                    Amount=ct.Value,
                };
            }).ToList();

            return categorizedTaxes;
        }
    }
}
