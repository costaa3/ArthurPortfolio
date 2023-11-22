using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MVVMCurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMCurrencyConverter.ViewModel
{
    public class CurrencyConverter : ObservableObject, IDataHolderService
    {
        #region Properties
        private decimal inputAmount;

        IFullDataHandler dataHolderService;

        public CurrencyConverter(IFullDataHandler dataHolderService)
        {
            this.dataHolderService = dataHolderService;
            PerformConversionCommand = new RelayCommand(PerformConversion);
            ClearCommand = new RelayCommand(ClearFields);
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
        public CurrencyType FromCurrency
        {
            get => fromCurrency; set
            {
                fromCurrency = value;
                RaisePropertyChanged();
            }
        }
        public CurrencyType ToCurrency
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
        public ObservableCollection<CurrencyType> CurrencyTypes
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
        private CurrencyType fromCurrency;
        private CurrencyType toCurrency;
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
