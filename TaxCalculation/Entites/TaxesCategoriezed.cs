using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;

namespace TaxCalculation
{
    public class TaxesCategoriezed
    {
        public TaxTypeGroup TaxtypeReference { get; set; }
        public TaxTypeEnum TaxTypeEnum { get; set; }
        public string EnglisghDescription { get; set; }
        public string ArabicDescription { get; set; }
        public decimal Amount { get; set; }
    }
}
