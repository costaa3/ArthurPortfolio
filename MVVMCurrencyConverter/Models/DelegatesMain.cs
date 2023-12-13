using MVVMCurrencyConverter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCurrencyConverter
{
    public delegate void UpdateDataOnSubscribed(IEnumerable<ICurrencyType> data);
    public delegate void UpdateLinkSelectionOnSubscribed(ICurrencyType selectedCurrency);
}
