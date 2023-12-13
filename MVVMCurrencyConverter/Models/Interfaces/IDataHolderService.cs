using MVVMCurrencyConverter.ViewModel;
using System.Collections.ObjectModel;

namespace MVVMCurrencyConverter.Models
{
    public interface IDataHolderService
    {
        ObservableCollection<ICurrencyType> CurrencyTypes { get; set; }
    }
}