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
    public class CurrencyMasterViewModel : ObservableObject
    {
        #region fields and properties

        #region fields
        IDataHandler dataHolderService;
        ApiHandling apiHandling = new ApiHandling();
        private decimal currencyValue;

        private string currencyName;
        public ICurrencyType SelectedLink { get { return dataHolderService?.CurrencyTypeSelected; } }

        private ObservableCollection<CurrencyTypeViewModel> currencyTypes = new ObservableCollection<CurrencyTypeViewModel>();
        public ICommand SaveCommand { get; }
        public ICommand ClearCommand { get; }


        #endregion

        #region Properties
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

        public ObservableCollection<CurrencyTypeViewModel> CurrencyTypes
        {
            get
            {
                return currencyTypes;
            }
            set
            {

                currencyTypes = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #endregion

        #region Methods

        private void processLinkSelectionChanges(ICurrencyType currency)
        {
            if (currency != null)
            {
                CurrencyName = currency.Name;
                CurrencyValue = currency.Value;
            }
            RaisePropertyChanged(nameof(SelectedLink));
        }

        private void UpdateData(IEnumerable<ICurrencyType> data)
        {
            CurrencyTypes = new ObservableCollection<CurrencyTypeViewModel>(data.Where(item => item?.Id != 0).Select(it => new CurrencyTypeViewModel(it, dataHolderService)));
        }

        private void ClearFields()
        {
            CurrencyName = "";
            CurrencyValue = 0m;
            dataHolderService.SetCurrencyBeingEditted(null);
        }

        public void SaveToDatabase()
        {
            if (dataHolderService.CurrencyTypeSelected == null)
            {
                dataHolderService.AppendToDatabase(currencyName, CurrencyValue);

            }

            else
            {
                dataHolderService.UpdataDbItem(currencyName, currencyValue);

            }
            ClearFields();
        }

        #endregion

        #region Constructor
        public CurrencyMasterViewModel(IDataHandler dataHolderService)
        {
            ClearCommand = new RelayCommand(ClearFields);
            SaveCommand = new RelayCommand(SaveToDatabase);

            this.dataHolderService = dataHolderService;
            dataHolderService.SubscribeToCurrenciesChangeSelection(UpdateData);
            dataHolderService.SubscribeToLinkSelection(processLinkSelectionChanges);
            UpdateData(dataHolderService.CurrencyTypes);
            
        }
        #endregion

    }
}
