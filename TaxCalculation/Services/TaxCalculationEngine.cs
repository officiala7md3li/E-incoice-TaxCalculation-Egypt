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
        private List<TaxTypeEnum> _cachedSortedTaxTypes;

        public TaxCalculationEngine(IDictionary<TaxTypeEnum, ITaxCalculationStrategy> strategies)
        {
            _strategies = strategies;
            // Pre-compute the topological sort once
            _cachedSortedTaxTypes = TopologicallySort(_strategies);
        }

        public IDictionary<TaxTypeEnum, decimal> CalculateTaxes(decimal baseAmount)
        {
            // Pre-allocate dictionary with known capacity to avoid resizing
            var computedTaxes = new Dictionary<TaxTypeEnum, decimal>(_cachedSortedTaxTypes.Count);
            
            foreach (var taxType in _cachedSortedTaxTypes)
            {
                var strategy = _strategies[taxType];
                computedTaxes[taxType] = strategy.Calculate(baseAmount, computedTaxes);
            }
            return computedTaxes;
        }

        // A simple topological sort to ensure dependencies are computed first.
        private List<TaxTypeEnum> TopologicallySort(IDictionary<TaxTypeEnum, ITaxCalculationStrategy> strategies)
        {
            var sorted = new List<TaxTypeEnum>(strategies.Count); // Pre-allocate capacity
            var visited = new Dictionary<TaxTypeEnum, bool>(strategies.Count);
            
            foreach (var taxType in strategies.Keys)
            {
                if (!visited.ContainsKey(taxType))
                {
                    Visit(taxType, strategies, visited, sorted);
                }
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
            
            var strategy = strategies[taxType];
            foreach (var dep in strategy.DependentTaxes)
            {
                if (strategies.ContainsKey(dep) && !sorted.Contains(dep))
                    Visit(dep, strategies, visited, sorted);
            }
            
            visited[taxType] = false;
            sorted.Add(taxType);
        }
    }

}
