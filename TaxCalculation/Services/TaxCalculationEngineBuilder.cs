using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;

namespace TaxCalculation.Services
{
    public class TaxCalculationEngineBuilder
    {
        private readonly Dictionary<TaxTypeEnum, ITaxCalculationStrategy> _strategies = new();
        public TaxCalculationEngineBuilder WithStrategy(TaxTypeEnum taxType, ITaxCalculationStrategy strategy)
        {
            _strategies[taxType] = strategy;
            return this;
        }
        public TaxCalculationEngine Build() => new TaxCalculationEngine(_strategies);
    }
}
