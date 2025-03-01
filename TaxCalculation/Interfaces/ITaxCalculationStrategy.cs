using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;

namespace TaxCalculation.Interfaces
{
    // Application Layer - Interfaces (Application/Interfaces/ITaxCalculationStrategy.cs)
    public interface ITaxCalculationStrategy
    {
        /// <summary>
        /// A list of tax types that should be added to the base before calculating this tax.
        /// </summary>
        IEnumerable<TaxTypeEnum> DependentTaxes { get; }

        /// <summary>
        /// Calculates the tax amount. The effective base may include amounts from dependencies.
        /// </summary>
        decimal Calculate(decimal baseAmount, IReadOnlyDictionary<TaxTypeEnum, decimal> computedTaxes);
    }
}
