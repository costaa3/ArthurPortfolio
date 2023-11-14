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
        #region Properties
        private decimal inputAmount;

        ObservableCollection<CurrencyType> currencyTypes = new ObservableCollection<CurrencyType>(CurrencyType.GetTestData());

        public decimal InputAmount
        {
            get => inputAmount;
            set
            {
                inputAmount = value;
                RaisePropertyChanged();
            }
        }
        public CurrencyType FromCurrency
        {
            get => fromCurrency; set
            {
                fromCurrency = value;
                RaisePropertyChanged();
            }
        }
        public CurrencyType ToCurrency { get => toCurrency; set {
                toCurrency = value;
                RaisePropertyChanged();
            } }
        public decimal Result
        {
            get => result; set
            {
                result = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<CurrencyType> CurrencyTypes
        {
            get => currencyTypes; set
            {
                currencyTypes = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PerformConversionCommand { get; }
        public ICommand ClearCommand { get; }
        private decimal result;
        private CurrencyType fromCurrency;
        private CurrencyType toCurrency;
        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            PerformConversionCommand = new RelayCommand(PerformConversion);
            ClearCommand = new RelayCommand(ClearFields);
        }

        #region Methods
        private void PerformConversion()
        {
            Result = CurrencyConversionTool.ConvertValue(InputAmount, FromCurrency, ToCurrency);
        }

        private void ClearFields()
        {
            InputAmount = 0m;
            Result = 0m;
            FromCurrency = CurrencyTypes[0];
            ToCurrency = CurrencyTypes[0];
        }

        #endregion

    }
}