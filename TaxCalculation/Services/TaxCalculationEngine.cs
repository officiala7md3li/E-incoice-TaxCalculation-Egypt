using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;
using TaxCalculation.Interfaces;

namespace TaxCalculation.Services
{
    // Application Layer - Engine & Builder (Application/Services/)
    /// <summary>
    /// The engine calculates all taxes. It first orders them so that if one tax depends on another,
    /// the dependency is computed first.
    /// </summary>
    public class TaxCalculationEngine
    {
        private readonly IDictionary<TaxTypeEnum, ITaxCalculationStrategy> _strategies;
        public TaxCalculationEngine(IDictionary<TaxTypeEnum, ITaxCalculationStrategy> strategies) => _strategies = strategies;

        public IDictionary<TaxTypeEnum, decimal> CalculateTaxes(decimal baseAmount)
        {
            var computedTaxes = new Dictionary<TaxTypeEnum, decimal>();
            var orderedTaxTypes = TopologicallySort(_strategies);
            foreach (var taxType in orderedTaxTypes)
            {
                var strategy = _strategies[taxType];
                computedTaxes[taxType] = strategy.Calculate(baseAmount, computedTaxes);
            }
            return computedTaxes;
        }

        // A simple topological sort to ensure dependencies are computed first.
        private List<TaxTypeEnum> TopologicallySort(IDictionary<TaxTypeEnum, ITaxCalculationStrategy> strategies)
        {
            var sorted = new List<TaxTypeEnum>();
            var visited = new Dictionary<TaxTypeEnum, bool>();
            foreach (var taxType in strategies.Keys)
            {
                Visit(taxType, strategies, visited, sorted);
            }
            return sorted;
        }

        private void Visit(TaxTypeEnum taxType, IDictionary<TaxTypeEnum, ITaxCalculationStrategy> strategies,
                           Dictionary<TaxTypeEnum, bool> visited, List<TaxTypeEnum> sorted)
        {
            if (visited.TryGetValue(taxType, out bool inProcess))
            {
                if (inProcess)
                    throw new Exception("Cyclic dependency detected");
                return;
            }
            visited[taxType] = true;
            foreach (var dep in strategies[taxType].DependentTaxes)
            {
                if (strategies.ContainsKey(dep))
                    Visit(dep, strategies, visited, sorted);
            }
            visited[taxType] = false;
            if (!sorted.Contains(taxType))
                sorted.Add(taxType);
        }
    }

}
