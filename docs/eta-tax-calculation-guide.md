# Egyptian Tax Authority (ETA) Calculation Specifications

## Standard VAT (T1)
- Rate: 14%
- Formula: VatAmount = NetTotal * 0.14

## Withholding Tax (W01 - W16)
- General Withholding Rate: 1% (Services / Commercial Supplies)
- Formula: WithholdingAmount = NetTotal * WithholdingRate

## Invoice Total Formulation
TotalInvoice = NetTotal + VatAmount - WithholdingAmount