using GalaSoft.MvvmLight;
using MVVMCurrencyConverter.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCurrencyConverter.Models
{
    public class DataHolderService : ObservableObject, IFullDataHandler
    {
        private IDatabaseHandler databaseHandler;

        public DataHolderService(IDatabaseHandler databaseHandler)
        {
            this.databaseHandler = databaseHandler;
            UpdateData();
        }

       

        public void UpdateData()
        {

            CurrencyTypes.Clear();
            CurrencyTypes.Add(CurrencyType.GetNulltData());

            foreach (var currencyType in databaseHandler.RetrieveAllDatabaseData())
            {
                CurrencyTypes.Add(currencyType.TuppleToCurrency());
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
        ObservableCollection<CurrencyType> currencyTypes = new ObservableCollection<CurrencyType>();
    }
}
