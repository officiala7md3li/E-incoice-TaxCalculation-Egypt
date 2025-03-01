using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Enums
{
    // Domain Layer - Enumerations (Domain/Enums/TaxTypeEnum.cs)
    // 2. Domain Layer – The TaxTypeEnum now uses the tax codes
    public enum TaxTypeEnum
    {
        // Group originally “T1” – exemptions / rate only
        V001, V002, V003, V004, V005, V006, V007, V008, V009, V010,
        //T2
        // Table taxes – originally T2 (rate) and T3 (fixed)
        Tbl01, // rate
        //T3
        Tbl02, // fixed
        //T4
        // Deduction taxes – originally T4 (all these codes are deductions)
        W001, W002, W003, W004, W005, W006, W007, W008, W009, W010, W011, W012, W013, W014, W015, W016,
        //T5
        // Stamping taxes – originally T5 (rate) and T6 (fixed)
        ST01, // rate
        //T6
        ST02, // fixed
        //T7
        // Entertainment taxes – a pair (rate and fixed)
        Ent01, // rate
        Ent02, // fixed
        //T8
        // Resource development fees – a pair (rate and fixed)
        RD01, // rate
        RD02, // fixed
        //T9
        // Service charges – a pair (rate and fixed)
        SC01, // rate
        SC02, // fixed
        //T10
        // Municipality fees – a pair (rate and fixed)
        Mn01, // rate
        Mn02, // fixed
        //T11
        // Medical insurance fees – a pair (rate and fixed)
        MI01, // rate
        MI02, // fixed
        //T12
        // Other fees – a pair (rate and fixed)
        OF01, // rate
        OF02, // fixed
        //T13
        // Additional stamping taxes – originally T13 (rate) and T14 (fixed)
        ST03, // rate
        //T14
        ST04, // fixed
        //T15
        // A second pair for entertainment, resource development, service charges, etc.
        Ent03, // rate
        Ent04, // fixed
        //T16
        RD03,  // rate
        RD04,  // fixed
        //T17
        SC03,  // rate
        SC04,  // fixed
        //T18
        Mn03,  // rate
        Mn04,  // fixed
        //T19
        MI03,  // rate
        MI04,  // fixed
        //T20
        OF03,  // rate
        OF04   // fixed
    }

}
