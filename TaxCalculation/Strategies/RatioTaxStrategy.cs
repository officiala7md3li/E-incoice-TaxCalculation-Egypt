using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;

namespace TaxCalculation.Strategies
{
    // Domain Layer - Concrete Strategies (Domain/Strategies/)
    /// <summary>
    /// A tax calculated as a percentage of an “effective” base.
    /// The effective base is the original base plus any dependency tax amounts.
    /// </summary>
    public class RatioTaxStrategy : ITaxCalculationStrategy
    {
        private readonly decimal _rate;
        private readonly bool _isDeduction;

        public IEnumerable<TaxTypeEnum> DependentTaxes { get; }

        public RatioTaxStrategy(decimal rate, bool isDeduction = false, IEnumerable<TaxTypeEnum>? dependencies = null)
        {
            _rate = rate;
            _isDeduction = isDeduction;
            DependentTaxes = dependencies?.ToList() ?? new List<TaxTypeEnum>();
        }

        public decimal Calculate(decimal baseAmount, IReadOnlyDictionary<TaxTypeEnum, decimal> computedTaxes)
        {
            // If dependencies exist, add their computed values to the base amount.
            decimal effectiveBase = baseAmount;
            foreach (var dep in DependentTaxes)
            {
                if (computedTaxes.TryGetValue(dep, out decimal depValue))
                {
                    effectiveBase += depValue;
                }
            }
            decimal taxAmount = effectiveBase * _rate;
            return _isDeduction ? -taxAmount : taxAmount;
        }
    }
}
