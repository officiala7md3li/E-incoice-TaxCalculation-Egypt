using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;

namespace TaxCalculation.Strategies
{
    /// <summary>
    /// A fixed‐amount tax (its value does not depend on the base amount).
    /// </summary>
    public class FixedTaxStrategy : ITaxCalculationStrategy
    {
        private readonly decimal _fixedAmount;
        public IEnumerable<TaxTypeEnum> DependentTaxes { get; } = new List<TaxTypeEnum>();

        public FixedTaxStrategy(decimal fixedAmount)
        {
            _fixedAmount = fixedAmount;
        }
        public decimal Calculate(decimal baseAmount, IReadOnlyDictionary<TaxTypeEnum, decimal> computedTaxes) => _fixedAmount;
    }

}
