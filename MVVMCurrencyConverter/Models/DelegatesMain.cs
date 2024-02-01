using MVVMCurrencyConverter.ViewModel;
using System.Collections.Generic;

namespace MVVMCurrencyConverter
{
    public delegate void UpdateDataOnSubscribed(IEnumerable<ICurrencyType> data);
    public delegate void UpdateLinkSelectionOnSubscribed(ICurrencyType selectedCurrency);
}
