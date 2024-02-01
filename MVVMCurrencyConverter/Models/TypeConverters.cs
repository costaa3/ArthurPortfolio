namespace MVVMCurrencyConverter.ViewModel
{
    public static class TypeConverters
    {
        public static CurrencyType TuppleToCurrency(this (int, string, decimal) input)
        {
            if (string.IsNullOrEmpty(input.Item2))
            {
                return null;
            }
            var result = CurrencyType.CurrencyFactory(input.Item1, input.Item2, input.Item3);
            return result;
        }


    }
}