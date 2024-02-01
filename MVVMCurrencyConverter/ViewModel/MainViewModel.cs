using GalaSoft.MvvmLight;

namespace MVVMCurrencyConverter.ViewModel
{


    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region constructor
        public MainViewModel(CurrencyConverterViewModel currencyConverter, CurrencyMasterViewModel currencyMaster)
        {
            CurrencyConverter = currencyConverter;
            CurrencyMaster = currencyMaster;
        }
        #endregion

        #region fields and properties
        public CurrencyConverterViewModel CurrencyConverter { get; }
        public CurrencyMasterViewModel CurrencyMaster { get; }
        #endregion

    }
}