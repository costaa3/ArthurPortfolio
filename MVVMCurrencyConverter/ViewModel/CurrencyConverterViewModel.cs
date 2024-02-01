using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MVVMCurrencyConverter.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMCurrencyConverter.ViewModel
{
    public class CurrencyConverterViewModel : ObservableObject, IDataHolderService
    {
        #region Properties
        private decimal inputAmount;

        IDataHandler dataHolderService;

        public CurrencyConverterViewModel(IDataHandler dataHolderService)
        {
            this.dataHolderService = dataHolderService;
            PerformConversionCommand = new RelayCommand(PerformConversion);
            ClearCommand = new RelayCommand(ClearFields);

            this.dataHolderService = dataHolderService;
            dataHolderService.SubscribeToCurrenciesChangeSelection(UpdateData);
        }

        private void UpdateData(IEnumerable<ICurrencyType> data)
        {
            CurrencyTypes = new ObservableCollection<ICurrencyType>(data);
        }

        public decimal InputAmount
        {
            get => inputAmount;
            set
            {
                inputAmount = value;
                RaisePropertyChanged();
            }
        }
        public ICurrencyType FromCurrency
        {
            get => fromCurrency; set
            {
                fromCurrency = value;
                RaisePropertyChanged();
            }
        }
        public ICurrencyType ToCurrency
        {
            get => toCurrency; set
            {
                toCurrency = value;
                RaisePropertyChanged();
            }
        }
        public decimal Result
        {
            get => result; set
            {
                result = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ICurrencyType> CurrencyTypes
        {
            get => dataHolderService.CurrencyTypes; set
            {
                dataHolderService.CurrencyTypes = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PerformConversionCommand { get; }
        public ICommand ClearCommand { get; }
        private decimal result;
        private ICurrencyType fromCurrency;
        private ICurrencyType toCurrency;
        #endregion


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
