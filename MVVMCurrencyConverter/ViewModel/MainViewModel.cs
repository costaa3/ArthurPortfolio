using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
        public MainViewModel(CurrencyConverter currencyConverter, CurrencyMaster currencyMaster)
        {
            CurrencyConverter = currencyConverter;
            CurrencyMaster = currencyMaster;


        }
        public CurrencyConverter CurrencyConverter { get; }
        public CurrencyMaster CurrencyMaster { get; }

    }
}