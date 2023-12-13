using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMCurrencyConverter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMCurrencyConverter.Models
{
    public class CurrencyTypeViewModel :ObservableObject, ICurrencyType
    {

        #region Properties and fields

        #region Properties
      

        public int Id
        {
            get => currency.Id; set
            {
                currency.Id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get => currency.Name; set
            {
                currency.Name = value;
                RaisePropertyChanged();
            }
        }

        public decimal Value
        {
            get => currency.Value; set
            {
                currency.Value = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region fields
        private ICurrencyType currency;
        private IDataHandler fullDataHandler;

        public ICommand DeleteItemCommand { get; }
        public ICommand SelectForEdittingCommand { get; }
        #endregion



        #endregion

        #region Methods
        private void DeleteItem()
        {
            fullDataHandler.DeleteData(this);
        }

        private void SelectForEditting()
        {
            fullDataHandler.SetCurrencyBeingEditted(this);
        }
        #endregion

        #region Constructor
        public CurrencyTypeViewModel(ICurrencyType currency, IDataHandler fullDataHandler)
        {
            this.currency = currency;
            this.fullDataHandler = fullDataHandler;
            DeleteItemCommand = new RelayCommand(DeleteItem);
            SelectForEdittingCommand = new RelayCommand(SelectForEditting);
        }
        #endregion
    }
}

