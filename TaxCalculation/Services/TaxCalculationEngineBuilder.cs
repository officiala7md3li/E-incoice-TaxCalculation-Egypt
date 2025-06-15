using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;
using TaxCalculation.Factories;

namespace TaxCalculation.Services
{
    public class TaxCalculationEngineBuilder
    {
        private readonly Dictionary<TaxTypeEnum, ITaxCalculationStrategy> _strategies = new();

        /// <summary>
        /// Adds a tax strategy using an existing ITaxCalculationStrategy instance.
        /// </summary>
        /// <param name="taxType">The tax type</param>
        /// <param name="strategy">The strategy instance</param>
        /// <returns>The builder instance for method chaining</returns>
        public TaxCalculationEngineBuilder WithStrategy(TaxTypeEnum taxType, ITaxCalculationStrategy strategy)
        {
            _strategies[taxType] = strategy;
            return this;
        }

        /// <summary>
        /// Adds a tax strategy by automatically creating the appropriate strategy based on the tax type and value.
        /// This is a convenience method that internally uses TaxStrategyFactory.
        /// </summary>
        /// <param name="taxType">The tax type</param>
        /// <param name="value">The tax value (rate for percentage taxes, amount for fixed taxes)</param>
        /// <returns>The builder instance for method chaining</returns>
        public TaxCalculationEngineBuilder WithStrategy(TaxTypeEnum taxType, decimal value)
        {
            var strategy = TaxStrategyFactory.CreateStrategy(taxType, value);
            _strategies[taxType] = strategy;
            return this;
        }

        public TaxCalculationEngine Build() => new TaxCalculationEngine(_strategies);
    }
}
