using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class CurrencyMaster : ObservableObject
    {
        private decimal currencyValue;
        private string currencyName;
        private IDatabaseHandler _databaseHandler;
        IFullDataHandler dataHolderService;
        public CurrencyMaster(IDatabaseHandler databaseHandler, IFullDataHandler dataHolderService)
        {
            ClearCommand = new RelayCommand(ClearFields);
            SaveCommand = new RelayCommand(SaveToDatabase);
            _databaseHandler = databaseHandler;
            this.dataHolderService = dataHolderService;
        }

        public decimal CurrencyValue
        {
            get => currencyValue; set
            {
                currencyValue = value;
                RaisePropertyChanged();
            }
        }
        public string CurrencyName
        {
            get => currencyName; set
            {
                currencyName = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand { get;}
        public ICommand ClearCommand { get;}
        

        private void ClearFields()
        {
            CurrencyName = "";
            currencyValue = 0m;
        }

        public void SaveToDatabase()
        {
            _databaseHandler.AppendToDatabase(currencyName, CurrencyValue);
            dataHolderService.UpdateData();
        }

        public ObservableCollection<CurrencyType> CurrencyTypes
        {
            get => dataHolderService.CurrencyTypes; set
            {
                dataHolderService.CurrencyTypes = value;
                RaisePropertyChanged();
            }
        }

    }
}
