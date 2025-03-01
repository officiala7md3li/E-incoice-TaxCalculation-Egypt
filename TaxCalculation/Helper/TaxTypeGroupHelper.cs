using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Enums;

namespace TaxCalculation.Infrastructure.Helpers
{
    public static class TaxTypeGroupHelper
    {
        private static readonly Dictionary<TaxTypeEnum, TaxTypeGroup> TaxTypeToGroup = new()
        {
            // Mapping based on the provided JSON data
            { TaxTypeEnum.V001, TaxTypeGroup.T1 }, { TaxTypeEnum.V002, TaxTypeGroup.T1 },
            { TaxTypeEnum.V003, TaxTypeGroup.T1 }, { TaxTypeEnum.V004, TaxTypeGroup.T1 },
            { TaxTypeEnum.V005, TaxTypeGroup.T1 }, { TaxTypeEnum.V006, TaxTypeGroup.T1 },
            { TaxTypeEnum.V007, TaxTypeGroup.T1 }, { TaxTypeEnum.V008, TaxTypeGroup.T1 },
            { TaxTypeEnum.V009, TaxTypeGroup.T1 }, { TaxTypeEnum.V010, TaxTypeGroup.T1 },

            { TaxTypeEnum.Tbl01, TaxTypeGroup.T2 }, { TaxTypeEnum.Tbl02, TaxTypeGroup.T3 },

            { TaxTypeEnum.W001, TaxTypeGroup.T4 }, { TaxTypeEnum.W002, TaxTypeGroup.T4 },
            { TaxTypeEnum.W003, TaxTypeGroup.T4 }, { TaxTypeEnum.W004, TaxTypeGroup.T4 },
            { TaxTypeEnum.W005, TaxTypeGroup.T4 }, { TaxTypeEnum.W006, TaxTypeGroup.T4 },
            { TaxTypeEnum.W007, TaxTypeGroup.T4 }, { TaxTypeEnum.W008, TaxTypeGroup.T4 },
            { TaxTypeEnum.W009, TaxTypeGroup.T4 }, { TaxTypeEnum.W010, TaxTypeGroup.T4 },
            { TaxTypeEnum.W011, TaxTypeGroup.T4 }, { TaxTypeEnum.W012, TaxTypeGroup.T4 },
            { TaxTypeEnum.W013, TaxTypeGroup.T4 }, { TaxTypeEnum.W014, TaxTypeGroup.T4 },
            { TaxTypeEnum.W015, TaxTypeGroup.T4 }, { TaxTypeEnum.W016, TaxTypeGroup.T4 },

            { TaxTypeEnum.ST01, TaxTypeGroup.T5 }, { TaxTypeEnum.ST02, TaxTypeGroup.T6 },

            { TaxTypeEnum.Ent01, TaxTypeGroup.T7 }, { TaxTypeEnum.Ent02, TaxTypeGroup.T7 },

            { TaxTypeEnum.RD01, TaxTypeGroup.T8 }, { TaxTypeEnum.RD02, TaxTypeGroup.T8 },

            { TaxTypeEnum.SC01, TaxTypeGroup.T9 }, { TaxTypeEnum.SC02, TaxTypeGroup.T9 },

            { TaxTypeEnum.Mn01, TaxTypeGroup.T10 }, { TaxTypeEnum.Mn02, TaxTypeGroup.T10 },

            { TaxTypeEnum.MI01, TaxTypeGroup.T11 }, { TaxTypeEnum.MI02, TaxTypeGroup.T11 },

            { TaxTypeEnum.OF01, TaxTypeGroup.T12 }, { TaxTypeEnum.OF02, TaxTypeGroup.T12 },

            { TaxTypeEnum.ST03, TaxTypeGroup.T13 }, { TaxTypeEnum.ST04, TaxTypeGroup.T14 },

            { TaxTypeEnum.Ent03, TaxTypeGroup.T15 }, { TaxTypeEnum.Ent04, TaxTypeGroup.T15 },

            { TaxTypeEnum.RD03, TaxTypeGroup.T16 }, { TaxTypeEnum.RD04, TaxTypeGroup.T16 },

            { TaxTypeEnum.SC03, TaxTypeGroup.T17 }, { TaxTypeEnum.SC04, TaxTypeGroup.T17 },

            { TaxTypeEnum.Mn03, TaxTypeGroup.T18 }, { TaxTypeEnum.Mn04, TaxTypeGroup.T18 },

            { TaxTypeEnum.MI03, TaxTypeGroup.T19 }, { TaxTypeEnum.MI04, TaxTypeGroup.T19 },

            { TaxTypeEnum.OF03, TaxTypeGroup.T20 }, { TaxTypeEnum.OF04, TaxTypeGroup.T20 }
        };

        public static TaxTypeGroup GetTaxTypeGroup(this TaxTypeEnum taxType)
        {
            if (TaxTypeToGroup.TryGetValue(taxType, out var group))
                return group;
            throw new ArgumentException($"TaxType {taxType} has no defined TaxTypeGroup.");
        }
    }
}
