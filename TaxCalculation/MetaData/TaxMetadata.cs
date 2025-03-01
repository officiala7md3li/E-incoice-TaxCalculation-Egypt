using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class TaxMetadata
    {
        public string Code { get; set; }
        public string Desc_en { get; set; }
        public string Desc_ar { get; set; }
        public string TaxtypeReference { get; set; }
    }
    public static class TaxMetadataRepository
    {
        // Static list containing all the tax metadata.
        private static readonly List<TaxMetadata> _taxMetadataList = new()
        {
            new TaxMetadata { Code = "V001", Desc_en = "Export", Desc_ar = "تصدير للخارج", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V002", Desc_en = "Export to free areas and other areas", Desc_ar = "تصدير مناطق حرة وأخرى", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V003", Desc_en = "Exempted good or service", Desc_ar = "سلعة أو خدمة معفاة", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V004", Desc_en = "A non-taxable good or service", Desc_ar = "سلعة أو خدمة غير خاضعة للضريبة", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V005", Desc_en = "Exemptions for diplomats, consulates and embassies", Desc_ar = "إعفاءات دبلوماسين والقنصليات والسفارات", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V006", Desc_en = "Defence and National security Exemptions", Desc_ar = "إعفاءات الدفاع والأمن القومى", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V007", Desc_en = "Agreements exemptions", Desc_ar = "إعفاءات اتفاقيات", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V008", Desc_en = "Special Exemptios and other reasons", Desc_ar = "إعفاءات خاصة و أخرى", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V009", Desc_en = "General Item sales", Desc_ar = "سلع عامة", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "V010", Desc_en = "Other Rates", Desc_ar = "نسب ضريبة أخرى", TaxtypeReference = "T1" },
            new TaxMetadata { Code = "Tbl01", Desc_en = "Table tax (percentage)", Desc_ar = "ضريبه الجدول (نسبيه)", TaxtypeReference = "T2" },
            new TaxMetadata { Code = "Tbl02", Desc_en = "Table tax (Fixed Amount)", Desc_ar = "ضريبه الجدول (النوعية)", TaxtypeReference = "T3" },
            new TaxMetadata { Code = "W001", Desc_en = "Contracting", Desc_ar = "المقاولات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W002", Desc_en = "Supplies", Desc_ar = "التوريدات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W003", Desc_en = "Purachases", Desc_ar = "المشتريات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W004", Desc_en = "Services", Desc_ar = "الخدمات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W005", Desc_en = "Sumspaid by the cooperative societies for car transportation to their members", Desc_ar = "المبالغ التي تدفعها الجميعات التعاونية للنقل بالسيارات لاعضائها", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W006", Desc_en = "Commissionagency & brokerage", Desc_ar = "الوكالةبالعمولة والسمسرة", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W007", Desc_en = "Discounts& grants & additional exceptional incentives granted by smoke &cement companies", Desc_ar = "الخصوماتوالمنح والحوافز الاستثنائية ةالاضافية التي تمنحها شركات الدخان والاسمنت", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W008", Desc_en = "Alldiscounts & grants & commissions granted by petroleum &telecommunications & other companies", Desc_ar = "جميع الخصومات والمنح والعمولات  التي تمنحها  شركات البترول والاتصالات ...وغيرها من الشركات المخاطبة بنظام الخصم", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W009", Desc_en = "Supporting export subsidies", Desc_ar = "مساندة دعم الصادرات التي يمنحها صندوق تنمية الصادرات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W010", Desc_en = "Professional fees", Desc_ar = "اتعاب مهنية", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W011", Desc_en = "Commission & brokerage _A_57", Desc_ar = "العمولة والسمسرة _م_57", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W012", Desc_en = "Hospitals collecting from doctors", Desc_ar = "تحصيل المستشفيات من الاطباء", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W013", Desc_en = "Royalties", Desc_ar = "الاتاوات", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W014", Desc_en = "Customs clearance", Desc_ar = "تخليص جمركي", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W015", Desc_en = "Exemption", Desc_ar = "أعفاء", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "W016", Desc_en = "advance payments", Desc_ar = "دفعات مقدمه", TaxtypeReference = "T4" },
            new TaxMetadata { Code = "ST01", Desc_en = "Stamping tax (percentage)", Desc_ar = "ضريبه الدمغه (نسبيه)", TaxtypeReference = "T5" },
            new TaxMetadata { Code = "ST02", Desc_en = "Stamping Tax (amount)", Desc_ar = "ضريبه الدمغه (قطعيه بمقدار ثابت)", TaxtypeReference = "T6" },
            new TaxMetadata { Code = "Ent01", Desc_en = "Entertainment tax (rate)", Desc_ar = "ضريبة الملاهى (نسبة)", TaxtypeReference = "T7" },
            new TaxMetadata { Code = "Ent02", Desc_en = "Entertainment tax (amount)", Desc_ar = "ضريبة الملاهى (قطعية)", TaxtypeReference = "T7" },
            new TaxMetadata { Code = "RD01", Desc_en = "Resource development fee (rate)", Desc_ar = "رسم تنميه الموارد (نسبة)", TaxtypeReference = "T8" },
            new TaxMetadata { Code = "RD02", Desc_en = "Resource development fee (amount)", Desc_ar = "رسم تنميه الموارد (قطعية)", TaxtypeReference = "T8" },
            new TaxMetadata { Code = "SC01", Desc_en = "Service charges (rate)", Desc_ar = "رسم خدمة (نسبة)", TaxtypeReference = "T9" },
            new TaxMetadata { Code = "SC02", Desc_en = "Service charges (amount)", Desc_ar = "رسم خدمة (قطعية)", TaxtypeReference = "T9" },
            new TaxMetadata { Code = "Mn01", Desc_en = "Municipality Fees (rate)", Desc_ar = "رسم المحليات (نسبة)", TaxtypeReference = "T10" },
            new TaxMetadata { Code = "Mn02", Desc_en = "Municipality Fees (amount)", Desc_ar = "رسم المحليات (قطعية)", TaxtypeReference = "T10" },
            new TaxMetadata { Code = "MI01", Desc_en = "Medical insurance fee (rate)", Desc_ar = "رسم التامين الصحى (نسبة)", TaxtypeReference = "T11" },
            new TaxMetadata { Code = "MI02", Desc_en = "Medical insurance fee (amount)", Desc_ar = "رسم التامين الصحى (قطعية)", TaxtypeReference = "T11" },
            new TaxMetadata { Code = "OF01", Desc_en = "Other fees (rate)", Desc_ar = "رسوم أخرى (نسبة)", TaxtypeReference = "T12" },
            new TaxMetadata { Code = "OF02", Desc_en = "Other fees (amount)", Desc_ar = "رسوم أخرى (قطعية)", TaxtypeReference = "T12" },
            new TaxMetadata { Code = "ST03", Desc_en = "Stamping tax (percentage)", Desc_ar = "ضريبه الدمغه (نسبيه)", TaxtypeReference = "T13" },
            new TaxMetadata { Code = "ST04", Desc_en = "Stamping Tax (amount)", Desc_ar = "ضريبه الدمغه (قطعيه بمقدار ثابت)", TaxtypeReference = "T14" },
            new TaxMetadata { Code = "Ent03", Desc_en = "Entertainment tax (rate)", Desc_ar = "ضريبة الملاهى (نسبة)", TaxtypeReference = "T15" },
            new TaxMetadata { Code = "Ent04", Desc_en = "Entertainment tax (amount)", Desc_ar = "ضريبة الملاهى (قطعية)", TaxtypeReference = "T15" },
            new TaxMetadata { Code = "RD03", Desc_en = "Resource development fee (rate)", Desc_ar = "رسم تنميه الموارد (نسبة)", TaxtypeReference = "T16" },
            new TaxMetadata { Code = "RD04", Desc_en = "Resource development fee (amount)", Desc_ar = "رسم تنميه الموارد (قطعية)", TaxtypeReference = "T16" },
            new TaxMetadata { Code = "SC03", Desc_en = "Service charges (rate)", Desc_ar = "رسم خدمة (نسبة)", TaxtypeReference = "T17" },
            new TaxMetadata { Code = "SC04", Desc_en = "Service charges (amount)", Desc_ar = "رسم خدمة (قطعية)", TaxtypeReference = "T17" },
            new TaxMetadata { Code = "Mn03", Desc_en = "Municipality Fees (rate)", Desc_ar = "رسم المحليات (نسبة)", TaxtypeReference = "T18" },
            new TaxMetadata { Code = "Mn04", Desc_en = "Municipality Fees (amount)", Desc_ar = "رسم المحليات (قطعية)", TaxtypeReference = "T18" },
            new TaxMetadata { Code = "MI03", Desc_en = "Medical insurance fee (rate)", Desc_ar = "رسم التامين الصحى (نسبة)", TaxtypeReference = "T19" },
            new TaxMetadata { Code = "MI04", Desc_en = "Medical insurance fee (amount)", Desc_ar = "رسم التامين الصحى (قطعية)", TaxtypeReference = "T19" },
            new TaxMetadata { Code = "OF03", Desc_en = "Other fees (rate)", Desc_ar = "رسوم أخرى (نسبة)", TaxtypeReference = "T20" },
            new TaxMetadata { Code = "OF04", Desc_en = "Other fees (amount)", Desc_ar = "رسوم أخرى (قطعية)", TaxtypeReference = "T20" },
        };

        // Public property to access all metadata.
        public static IReadOnlyList<TaxMetadata> Data => _taxMetadataList;

        // Retrieve a single TaxMetadata by its code.
        public static TaxMetadata GetByCode(string code)
        {
            return _taxMetadataList.FirstOrDefault(t =>
                t.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }
    }
}
