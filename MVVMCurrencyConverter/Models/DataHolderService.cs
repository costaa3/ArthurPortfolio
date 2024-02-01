using MVVMCurrencyConverter.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMCurrencyConverter.Models
{
    public class DataHolderService : IDataHandler
    {
        private IDatabaseHandler databaseHandler;
        private ICurrencyType selectedCurrencyType;


        public DataHolderService(IDatabaseHandler databaseHandler)
        {
            this.databaseHandler = databaseHandler;
            UpdateData();
        }



        private event UpdateDataOnSubscribed updateDataOnSubscribedEvent;
        private event UpdateLinkSelectionOnSubscribed UpdateLinkSelectionEvent;

        public void DeleteData(ICurrencyType currency)
        {
            databaseHandler.DeleteDatabaseItem(currency.Id);
            UpdateData();
        }

        public void UpdataDbItem(string name, decimal value)
        {
            databaseHandler.UpdateDatabaseItem(selectedCurrencyType.Id, name, value);
            UpdateData();
            CurrencyTypeSelected = null;

        }

        public void UpdateData()
        {

            CurrencyTypes.Clear();
            CurrencyTypes.Add(CurrencyType.GetDefaultItem());

            foreach (var currencyType in databaseHandler.RetrieveAllDatabaseData())
            {
                CurrencyTypes.Add(currencyType.TuppleToCurrency());
            }
            updateDataOnSubscribedEvent?.Invoke(CurrencyTypes.Select(it => new CurrencyTypeViewModel(it, this)));
        }

        public void AppendToDatabase(string currencyName, decimal CurrencyValue)
        {
            databaseHandler.AppendToDatabase(currencyName, CurrencyValue);
            UpdateData();
        }

        public void SetCurrencyBeingEditted(ICurrencyType currencyType)
        {
            CurrencyTypeSelected = currencyType;

        }

        public void SubscribeToLinkSelection(UpdateLinkSelectionOnSubscribed UpdateLinkSelectiondelegate)
        {
            UpdateLinkSelectionEvent += UpdateLinkSelectiondelegate;
        }

        public void SubscribeToCurrenciesChangeSelection(UpdateDataOnSubscribed UpdateDataOnSubscribedDelegate)
        {
            updateDataOnSubscribedEvent += UpdateDataOnSubscribedDelegate;
        }

        public ObservableCollection<ICurrencyType> CurrencyTypes
        {
            get => currencyTypes; set
            {
                currencyTypes = value;
            }
        }

        public ICurrencyType CurrencyTypeSelected
        {
            private set
            {
                selectedCurrencyType = value;
                UpdateLinkSelectionEvent?.Invoke(value);
            }
            get
            {
                return selectedCurrencyType;
            }
        }

        ObservableCollection<ICurrencyType> currencyTypes = new ObservableCollection<ICurrencyType>();
    }
}
