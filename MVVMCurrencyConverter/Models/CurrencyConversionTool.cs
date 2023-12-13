namespace MVVMCurrencyConverter.ViewModel
{
    public static class CurrencyConversionTool
    {
        public static decimal ConvertValue(decimal input, ICurrencyType fromCurrency, ICurrencyType toCurrency) { 
            if(fromCurrency==null || toCurrency==null) return 0;
            return input * (fromCurrency.Value / toCurrency.Value);
        }

            
    }
}